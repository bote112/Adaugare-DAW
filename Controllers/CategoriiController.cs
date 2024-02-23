using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAW.Models;
using DAW.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAW.Controllers
{
    public class CategoriiController : Controller
    {
        private readonly ICategoriiService _categoriiService;

        public CategoriiController(ICategoriiService categoriiService)
        {
            _categoriiService = categoriiService;
        }

        // GET: Categorii
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var categorii = await _categoriiService.GetAllCategoriiAsync();
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
                await _categoriiService.CreateCategorieAsync(categorie);
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

            var categorie = await _categoriiService.GetCategorieByIdAsync(id.Value);
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
                await _categoriiService.UpdateCategorieAsync(categorie);
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

            var categorie = await _categoriiService.GetCategorieByIdAsync(id.Value);
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
            await _categoriiService.DeleteCategorieAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
