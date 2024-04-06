using E_commerce.Data.Base;
using E_commerce.Data.ViewModel;
using E_commerce.Models;

namespace E_commerce.Data.Services
{
    public interface IMovieService:IEntityBaseRepo<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<MovieDropdownVM> MovieDropdownVMValues();
        Task AddNewMovieAsync(MovieVM data);
        Task updateMovieAsync(MovieVM data);
    }
}
