using System.ComponentModel.DataAnnotations;

namespace CollegeFestMVC.Models;

public class Participant
{
    public int ParticipantId { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string ParticipantName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Enter a valid email")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Department is required")]
    public string Department { get; set; } = string.Empty;

    [Required(ErrorMessage = "Year is required")]
    public string Year { get; set; } = string.Empty;

    [Required(ErrorMessage = "Select an event")]
    public string EventName { get; set; } = string.Empty;

    public bool IsTeamEvent { get; set; }

    public decimal? RegistrationFee { get; set; }

    public bool IsRegistrationComplete { get; set; }
}