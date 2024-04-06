using E_commerce.Data.Base;
using E_commerce.Data.ViewModel;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Data.Services
{
    public class MovieService:EntityBaseRepo<Movie>,IMovieService
    {
        private readonly AppDbContext _context;
        public MovieService(AppDbContext context): base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(MovieVM data)
        {
            var movie = new Movie()
            {
                Name = data.Name,
                Discription = data.Description,
                price = data.price,
                picUrl = data.picUrl,
                cinemaId = data.cinemaId,
                startTime = data.startTime,
                endTime = data.endTime,
                movieCategory = data.movieCategory,
                producerId = data.producerId

            };
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            //add movie actors
            foreach(var NEWactorid in data.ActorsId)
            {
                var newActorMovie = new Actor_movie()
                {
                    movieId = movie.Id,
                    actorId = NEWactorid
                };
                await _context.Actors_movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(c => c.cinema)
                .Include(p => p.producer)
                .Include(am => am.actor_Movies).ThenInclude(a => a.actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            if (movieDetails == null)
            {
                throw new ArgumentException("Movie with the specified ID not found.");
            }

            return movieDetails;
        }

        public async Task<MovieDropdownVM> MovieDropdownVMValues()
        {
            var response = new MovieDropdownVM()
            {
                actors = await _context.Actors.OrderBy(a => a.Name).ToListAsync(),
                cinemas = await _context.cinemas.OrderBy(a => a.Name).ToListAsync(),
                producers = await _context.Producers.OrderBy(a => a.Name).ToListAsync()
            };

            return response;
        }

        public async Task updateMovieAsync(MovieVM data)
        {
            var dbmovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.id);
            
            if (dbmovie != null)
            {


                dbmovie.Name = data.Name;
                dbmovie.Discription = data.Description;
                    dbmovie.price = data.price;
                dbmovie.picUrl = data.picUrl;
                dbmovie.cinemaId = data.cinemaId;
                dbmovie.startTime = data.startTime;
                    dbmovie.endTime = data.endTime;
                dbmovie.movieCategory = data.movieCategory;
                dbmovie.producerId = data.producerId;
                 await _context.SaveChangesAsync();
            }
            //Remove existing actors
            var existingActorsDb=_context.Actors_movies.Where(n=>n.movieId==data.id).ToList();
            _context.Actors_movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //add movie actors
            foreach (var NEWactorid in data.ActorsId)
            {
                var newActorMovie = new Actor_movie()
                {
                    movieId = data.id,
                    actorId = NEWactorid
                };
                await _context.Actors_movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();

        }
    }
}
