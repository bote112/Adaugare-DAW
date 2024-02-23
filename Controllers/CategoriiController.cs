using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAW.Models;
using DAW.Repositories;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    [Authorize]
    public class CategoriiController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriiController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Categorii
        public async Task<IActionResult> Index()
        {
            var categorii = await _unitOfWork.Categorii.GetAllAsync();
            return View(categorii);
        }

        // GET: Categorii/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nume")] Categorii categorie)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Categorii.CreateAsync(categorie);
                await Task.Run(() => _unitOfWork.Complete());
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categorii/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _unitOfWork.Categorii.GetByIdAsync(id.Value);
            if (categorie == null)
            {
                return NotFound();
            }
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nume")] Categorii categorie)
        {
            if (id != categorie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _unitOfWork.Categorii.UpdateAsync(categorie);
                await Task.Run(() => _unitOfWork.Complete());
                return RedirectToAction(nameof(Index));
            }
            return View(categorie);
        }

        // GET: Categorii/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categorie = await _unitOfWork.Categorii.GetByIdAsync(id.Value);
            if (categorie == null)
            {
                return NotFound();
            }

            return View(categorie);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _unitOfWork.Categorii.DeleteAsync(id);
            await Task.Run(() => _unitOfWork.Complete());
            return RedirectToAction(nameof(Index));
        }
    }
}
