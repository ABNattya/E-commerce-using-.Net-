using E_commerce.Data;
using E_commerce.Data.Services;
using E_commerce.Data.Static;
using E_commerce.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_commerce.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]

    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var movies=await _movieService.GetEntitiesAsync(n=>n.cinema);
            return View(movies);
        }
        [AllowAnonymous]

        public async Task<IActionResult> Filter(string Searching)
        {
            var movies = await _movieService.GetEntitiesAsync(n => n.cinema);

            if(!string.IsNullOrEmpty(Searching))
            {
                var result =movies.Where(n=>n.Name.Contains(Searching) || n.Discription.Contains(Searching) || n.Name.ToLower().Contains(Searching) || n.Discription.ToLower().Contains(Searching));
                return View("Index", result);

            }
            return View(movies);
        }


        //GET: Movies/details/
        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            var movieDetails=await _movieService.GetMovieByIdAsync(id);
            return View(movieDetails);
        }
        //GET: Movies/Create

        public async Task<IActionResult> Create()
        {
            var movieDropdown = await _movieService.MovieDropdownVMValues();
            ViewBag.cinemas = new SelectList(movieDropdown.cinemas, "Id", "Name");
            ViewBag.producers = new SelectList(movieDropdown.producers, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdown.actors, "Id", "Name");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieVM movie)
        {
            if(!ModelState.IsValid)
            {
                var movieDropdown = await _movieService.MovieDropdownVMValues();
                ViewBag.cinemas = new SelectList(movieDropdown.cinemas, "Id", "Name");
                ViewBag.producers = new SelectList(movieDropdown.producers, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdown.actors, "Id", "Name");
                return View(movie);

            }
            await _movieService.AddNewMovieAsync(movie);
            return RedirectToAction(nameof(Index)); 
        }

        //GET: Movies/Edit/1

        public async Task<IActionResult> Edit( int id)
        {
            var moviee=await _movieService.GetMovieByIdAsync(id);

            if(moviee==null)return View("NotFound");

            var response = new MovieVM()
            {
                id = moviee.Id,
                Name = moviee.Name,
                Description = moviee.Discription,
                price = moviee.price,
                picUrl = moviee.picUrl,
                cinemaId = moviee.cinemaId,
                startTime = moviee.startTime,
                endTime = moviee.endTime,
                movieCategory = moviee.movieCategory,
                producerId = moviee.producerId

            };

            var movieDropdown = await _movieService.MovieDropdownVMValues();
            ViewBag.cinemas = new SelectList(movieDropdown.cinemas, "Id", "Name");
            ViewBag.producers = new SelectList(movieDropdown.producers, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdown.actors, "Id", "Name");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,MovieVM movie)
        {
            if(id!=movie.id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdown = await _movieService.MovieDropdownVMValues();
                ViewBag.cinemas = new SelectList(movieDropdown.cinemas, "Id", "Name");
                ViewBag.producers = new SelectList(movieDropdown.producers, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropdown.actors, "Id", "Name");
                return View(movie);

            }
            await _movieService.updateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}
