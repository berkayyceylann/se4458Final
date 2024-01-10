using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

public class TimedHostedService : BackgroundService
{
    private readonly TimeSpan _scheduleTime;

    public TimedHostedService()
    {
        
        _scheduleTime = new TimeSpan(3, 0, 0); 
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var currentTime = DateTime.Now;
            var nextRunTime = currentTime.Date.Add(_scheduleTime);
            if (currentTime > nextRunTime)
            {
                nextRunTime = nextRunTime.AddDays(1);
            }

            var waitTime = nextRunTime - currentTime;

            if (waitTime > TimeSpan.Zero)
            {
                await Task.Delay(waitTime, stoppingToken);
            }

            
            DoWork();
        }
    }

    private void DoWork()
    {
       
        Console.WriteLine("Zamanlanmış görev çalıştı: " + DateTime.Now);
    }
}