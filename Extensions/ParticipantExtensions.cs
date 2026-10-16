using CollegeFestMVC.Models;

namespace CollegeFestMVC.Extensions;

public static class ParticipantExtensions
{
    public static string GetRegistrationStatus(
        this Participant participant)
    {
        return participant.IsRegistrationComplete
            ? "Confirmed"
            : "Pending";
    }

    public static string GetFeeCategory(
        this Participant participant)
    {
        decimal fee = participant.RegistrationFee ?? 0;

        if (fee == 0)
            return "Free Event";

        if (fee <= 500)
            return "Standard Event";

        return "Premium Event";
    }
}