using E_commerce.Data;
using E_commerce.Data.Services;
using E_commerce.Data.Static;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace E_commerce.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class CinemasController : Controller
    {
        private readonly ICinemaService _service;

        public CinemasController(ICinemaService service)
        {
            _service = service;
        }
        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var allCinemas = await _service.GetActorsAsync();
            return View(allCinemas);
        }
        
        // Get cineams / create

        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create ([Bind("Name,discription,logoUrl")] cinema cinema)
        {
            ModelState.Remove("Movies");

            if (!ModelState.IsValid)
            {
                return View(cinema);
            }

            await _service.AddActorAsync(cinema);
            return RedirectToAction(nameof(Index));
        }
        //Get: Cinemas/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var cinemaDetails = await _service.GetActorByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var cinemaDetails = await _service.GetActorByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Logo,Name,Description")] cinema cinema)
        {
            if (!ModelState.IsValid) return View(cinema);
            await _service.updateActorAsync(id, cinema);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var cinemaDetails = await _service.GetActorByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");
            return View(cinemaDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var cinemaDetails = await _service.GetActorByIdAsync(id);
            if (cinemaDetails == null) return View("NotFound");

            await _service.deleteActor(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
