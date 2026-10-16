using Microsoft.AspNetCore.Mvc;
using CollegeFestMVC.Models;

namespace CollegeFestMVC.Controllers;

public class FestController : Controller
{
    private static readonly List<Participant> participants = new();

    private static int nextId = 1;

    private static readonly List<Event> events = new()
    {
        new Event
        {
            EventId = 1,
            EventName = "Coding Competition",
            MaximumParticipants = 100,
            RegistrationFee = 200
        },
        new Event
        {
            EventId = 2,
            EventName = "Web Development",
            MaximumParticipants = 80,
            RegistrationFee = 300
        },
        new Event
        {
            EventId = 3,
            EventName = "Tech Quiz",
            MaximumParticipants = 100,
            RegistrationFee = 0
        },
        new Event
        {
            EventId = 4,
            EventName = "Robotics",
            MaximumParticipants = 50,
            RegistrationFee = 600
        }
    };

    public IActionResult Index()
    {
        return View(participants);
    }

    [HttpGet]
    public IActionResult Register()
    {
        ViewBag.Events = events;
        return View(new Participant());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Register(Participant participant)
    {
        ViewBag.Events = events;

        if (!ModelState.IsValid)
        {
            return View(participant);
        }

        Event? selectedEvent = events.FirstOrDefault(
            e => e.EventName == participant.EventName);

        if (selectedEvent == null)
        {
            ModelState.AddModelError(
                "EventName", "Please select a valid event.");

            return View(participant);
        }

        participant.ParticipantId = nextId++;
        participant.RegistrationFee = selectedEvent.RegistrationFee;
        participant.IsRegistrationComplete = true;

        participants.Add(participant);

        TempData["Success"] =
            "Participant registered successfully!";

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Details(int id)
    {
        Participant? participant = participants.FirstOrDefault(
            p => p.ParticipantId == id);

        if (participant == null)
        {
            return NotFound();
        }

        return View(participant);
    }

    public IActionResult Welcome()
    {
        return View();
    }
}