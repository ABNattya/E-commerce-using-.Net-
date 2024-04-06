using E_commerce.Data.Base;
using E_commerce.Models;
using Microsoft.EntityFrameworkCore;

namespace E_commerce.Data.Services
{
    public class ActorsService : EntityBaseRepo <Actor>, IActorsService

    {
        private readonly AppDbContext _context;

        public ActorsService (AppDbContext context):base(context) { }
        

    }
}
