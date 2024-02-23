using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAW.Models;
using DAW.Repositories;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAW.Controllers
{
    [Authorize]
    public class StiriController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public StiriController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Stiri
        public async Task<IActionResult> Index()
        {
            var stiri = await _unitOfWork.Stiri.GetAllAsync();
            return View(stiri);
        }

        // GET: Stiri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stire = await _unitOfWork.Stiri.GetByIdAsync(id.Value);
            if (stire == null)
            {
                return NotFound();
            }

            return View(stire);
        }

        // GET: Stiri/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stiri/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titlu,Continut,DataPublicarii,CategorieId")] Stiri stire)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Stiri.CreateAsync(stire);
                await _unitOfWork.CompleteAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stire);
        }

        // GET: Stiri/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stire = await _unitOfWork.Stiri.GetByIdAsync(id.Value);
            if (stire == null)
            {
                return NotFound();
            }
            return View(stire);
        }

        // POST: Stiri/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titlu,Continut,DataPublicarii,CategorieId")] Stiri stire)
        {
            if (id != stire.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Stiri.UpdateAsync(stire);
                    await _unitOfWork.CompleteAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await StireExists(stire.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stire);
        }

        // GET: Stiri/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stire = await _unitOfWork.Stiri.GetByIdAsync(id.Value);
            if (stire == null)
            {
                return NotFound();
            }

            return View(stire);
        }

        // POST: Stiri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Stiri.DeleteAsync(id);
            await _unitOfWork.CompleteAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StireExists(int id)
        {
            return await _unitOfWork.Stiri.GetByIdAsync(id) != null;
        }
    }
}
