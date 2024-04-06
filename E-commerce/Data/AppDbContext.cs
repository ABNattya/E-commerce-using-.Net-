using E_commerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;



namespace E_commerce.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_movie>().HasKey(am => new
            {
                am.actorId,
                am.movieId
            }

            );
            modelBuilder.Entity<Actor_movie>().HasOne(m => m.movie).WithMany(am => am.actor_Movies).HasForeignKey(m => m.movieId);
            modelBuilder.Entity<Actor_movie>().HasOne(a => a.actor).WithMany(am => am.actor_Movies).HasForeignKey(a => a.actorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor>Actors { get; set; }
        public DbSet<Actor_movie> Actors_movies { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<cinema> cinemas { get; set; }


        // order related table 
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }




    }
}
