using System.ComponentModel.DataAnnotations;

namespace BloodDonorSystem.Models;

public class BloodRequest
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Patient name is required.")]
    public string PatientName { get; set; }

    [Required(ErrorMessage = "Requestor hospital is required.")]
    public string RequestorHospital { get; set; }

    [Required(ErrorMessage = "Blood type is required.")]
    public string BloodType { get; set; }

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Town is required.")]
    public string Town { get; set; }

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Number of units must be at least 1.")]
    public int NumberOfUnits { get; set; }

    public string DurationOfSearch { get; set; }

    public string Reason { get; set; }
}