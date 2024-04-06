using E_commerce.Data;
using E_commerce.Data.Services;
using E_commerce.Data.Static;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Controllers
{
    [Authorize(Roles =UserRoles.Admin)]
    public class ProducerController : Controller
    {
        private readonly IproducerService _service;

        public ProducerController(IproducerService service)
        {
            _service = service;
        }

        [AllowAnonymous]

        public async Task<IActionResult> Index()
        {
            var allproducers =await _service.GetActorsAsync();
            return View(allproducers);
        }

        // Producer/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("picUrl", "Name", "bio")] Producer producer)
        {
            ModelState.Remove("Movies");

            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.AddActorAsync(producer);
            return RedirectToAction(nameof(Index));
        }


        //get details 
        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var result = await _service.GetActorByIdAsync(id);
            if (result == null) { return View("NotFound"); }
            else
            {
                return View(result);
            }

        }

        public async Task<IActionResult> Edit(int id)
        {
            var editProducer = await _service.GetActorByIdAsync(id);
            if (editProducer == null)
            {
                return View("NotFound");
            }
            return View(editProducer);
        }

        [HttpPost]
        //edit
        public async Task<IActionResult> Edit(int id, [Bind("Id,picUrl", "Name", "bio")] Producer producer)
        {
            ModelState.Remove("Movies");

            if (!ModelState.IsValid)
            {
                return View(producer);
            }

            await _service.updateActorAsync(id, producer);
            return RedirectToAction(nameof(Index));
        }

        //delete
        public async Task<IActionResult> Delete(int id)
        {
            var editProducer = await _service.GetActorByIdAsync(id);
            if (editProducer == null)
            {
                return View("NotFound");
            }
            return View(editProducer);
        }

        [HttpPost, ActionName("Delete")]
        //delete
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var editProducer = await _service.GetActorByIdAsync(id);
            if (editProducer == null)
            {
                return View("NotFound");
            }
            await _service.deleteActor(id);
            return RedirectToAction(nameof(Index));
        }


    }
}
