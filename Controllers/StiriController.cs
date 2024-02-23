using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DAW.Models;
using DAW.Services; // Include serviciul
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DAW.Controllers
{
    public class StiriController : Controller
    {
        private readonly IStiriService _stiriService;

        public StiriController(IStiriService stiriService)
        {
            _stiriService = stiriService;
        }

        // GET: Stiri
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var stiri = await _stiriService.GetAllStiriAsync();
            return View(stiri);
        }

        // GET: Stiri/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stire = await _stiriService.GetStireByIdAsync(id.Value);
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
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titlu,Continut,DataPublicarii,CategorieId")] Stiri stire)
        {
            if (ModelState.IsValid)
            {
                await _stiriService.CreateStireAsync(stire);
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

            var stire = await _stiriService.GetStireByIdAsync(id.Value);
            if (stire == null)
            {
                return NotFound();
            }
            return View(stire);
        }

        // POST: Stiri/Edit/5
        [Authorize(Roles = "Admin")]
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
                    await _stiriService.UpdateStireAsync(stire);
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

            var stire = await _stiriService.GetStireByIdAsync(id.Value);
            if (stire == null)
            {
                return NotFound();
            }

            return View(stire);
        }

        // POST: Stiri/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _stiriService.DeleteStireAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StireExists(int id)
        {
            // Această funcție poate fi mutată în serviciu dacă preferi să centralizezi logica
            var stire = await _stiriService.GetStireByIdAsync(id);
            return stire != null;
        }
    }
}
