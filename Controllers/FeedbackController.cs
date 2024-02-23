using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAW.Models;
using DAW.Repositories;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Feedback
        public async Task<IActionResult> Index()
        {
            var feedbacks = await _unitOfWork.Feedbacks.GetAllFeedbackAsync();
            return View(feedbacks);
        }

        // GET: Feedback/Create
        [Authorize(Roles = "User, Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StireId,UtilizatorId,Scor,Comentariu")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Feedbacks.CreateFeedbackAsync(feedback);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }

        // Adaugă aici metodele pentru Edit, Delete, etc., folosind _unitOfWork.Feedbacks și _unitOfWork.CompleteAsync() după necesitate
    }
}
