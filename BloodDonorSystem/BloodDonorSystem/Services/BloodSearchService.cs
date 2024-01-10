using BloodDonorSystem.Data;
using BloodDonorSystem.Models;
using Microsoft.EntityFrameworkCore;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using IModel = Microsoft.EntityFrameworkCore.Metadata.IModel;


public class BloodSearchService
{
    private readonly AppDbContext _context;
    private readonly IModel _channel;
    private readonly string _queueName;

    public BloodSearchService(AppDbContext context, IModel channel, string queueName)
    {
        _context = context;
        _channel = channel;
        _queueName = queueName;
    }

   

    public async Task SearchAndQueueUnfulfilledRequestsAsync()
    {
        var unfulfilledRequests = await _context.BloodRequests
            .Where(br => !br.IsFulfilled && br.RequestDate.AddDays(1) <= DateTime.Now)
            .ToListAsync();

        foreach (var request in unfulfilledRequests)
        {
            string message = JsonSerializer.Serialize(request);
            var body = Encoding.UTF8.GetBytes(message);
            
            
            
            
            _channel.BasicPublish(exchange: "",
                routingKey: _queueName,
                basicProperties: null,
                body: body);
            
            Console.WriteLine($" [x] Sent {message}");
        }
    }
    
    
    public void InitializeRabbitMQ()
    {
        _channel.QueueDeclare(queue: _queueName,
            durable: true,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }
    
    
}