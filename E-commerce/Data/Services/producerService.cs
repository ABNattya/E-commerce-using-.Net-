using E_commerce.Data.Base;
using E_commerce.Models;

namespace E_commerce.Data.Services
{
    public class producerService :EntityBaseRepo<Producer>, IproducerService
    {
        private readonly AppDbContext _context;

        public producerService(AppDbContext context) : base(context) { }
    
    }
}
