using E_commerce.Data;
using E_commerce.Data.Services;
using E_commerce.Data.Static;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetActorsAsync();
            return View(data);
        }

        // get Actors/Create
        public IActionResult Create ()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("picUrl", "Name", "bio")] Actor actor)
        {
            ModelState.Remove("actor_Movies");

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.AddActorAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //get details 
        [AllowAnonymous]

        public async Task<IActionResult> Details (int id)
        {
            var result=await _service.GetActorByIdAsync(id);
            if(result == null) { return View("NotFound"); }
            else
            {
                return View(result);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var editActor=await _service.GetActorByIdAsync(id);
            if(editActor == null)
            {
                return View("NotFound");
            }
            return View(editActor);
        }

        [HttpPost]
        //edit
        public async Task<IActionResult> Edit(int id,[Bind("Id,picUrl", "Name", "bio")] Actor actor)
        {
            ModelState.Remove("actor_Movies");

            if (!ModelState.IsValid)
            {
                return View(actor);
            }

            await _service.updateActorAsync(id,actor);
            return RedirectToAction(nameof(Index));
        }

        //delete
        public async Task<IActionResult> Delete(int id)
        {
            var editActor = await _service.GetActorByIdAsync(id);
            if (editActor == null)
            {
                return View("NotFound");
            }
            return View(editActor);
        }

        [HttpPost,ActionName("Delete")]
        //delete
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editActor = await _service.GetActorByIdAsync(id);
            if (editActor == null)
            {
                return View("NotFound");
            }
            await _service.deleteActor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
