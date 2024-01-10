using System.ComponentModel.DataAnnotations;

namespace BloodDonorSystem.Models;

public class Donor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full name is required.")]
    public string FullName { get; set; }

    [Required(ErrorMessage = "Blood type is required.")]
    public string BloodType { get; set; }

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Town is required.")]
    public string Town { get; set; }

    [Phone(ErrorMessage = "Invalid phone number.")]
    public string PhoneNumber { get; set; }
}