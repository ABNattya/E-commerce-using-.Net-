using E_commerce.Models;
using E_commerce.Data.Base;

namespace E_commerce.Data.Services
{
    public class CinemaService : EntityBaseRepo <cinema>, ICinemaService
    {
        private readonly AppDbContext _context;

    public CinemaService(AppDbContext context) : base(context) { }
    
    }
}
