using System.ComponentModel.DataAnnotations;

namespace BloodDonorSystem.Models;

public class BloodBank
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Branch name is required.")]
    [StringLength(100, ErrorMessage = "Branch name cannot be longer than 100 characters.")]
    public string BranchName { get; set; }

    [Required(ErrorMessage = "City is required.")]
    [StringLength(50, ErrorMessage = "City name cannot be longer than 50 characters.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Town is required.")]
    [StringLength(50, ErrorMessage = "Town name cannot be longer than 50 characters.")]
    public string Town { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Units available must be a non-negative number.")]
    public int UnitsAvailable { get; set; }
}