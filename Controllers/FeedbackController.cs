using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAW.Models;
using DAW.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        // GET: Feedback
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _feedbackService.GetAllFeedbackAsync();
            return View(feedbacks);
        }

        // GET: Feedback/Create
        [Authorize(Roles = "User, Admin")]
        public IActionResult Create()
        {
            // Implementează logica pentru popularea oricăror date necesare pentru formular
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StireId,UtilizatorId,Scor,Comentariu")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                await _feedbackService.CreateFeedbackAsync(feedback);
                return RedirectToAction(nameof(Index));
            }
            // Implementează logica pentru re-popularea oricăror date necesare pentru formular în caz de eroare
            return View(feedback);
        }

        // Implementează metodele pentru Edit, Details, Delete, etc., utilizând _feedbackService
        // pentru a efectua operațiuni specifice pe date, similar cu cele pentru Create și Index.
    }
}
