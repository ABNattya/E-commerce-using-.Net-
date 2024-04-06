using E_commerce.Data.enums;
using E_commerce.Data.Static;
using E_commerce.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;

namespace E_commerce.Data
{
    public class AppDbInitializar
    {
        public static void seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope =applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Cinema
                if (!context.cinemas.Any())
                {
                    context.cinemas.AddRange(new List<cinema>()
                    {
                        new cinema()
                        {
                            Name = "Cinema 1",
                            logoUrl = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            discription = "This is the description of the first cinema"
                        },
                        new cinema()
                        {
                            Name = "Cinema 2",
                            logoUrl = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            discription = "This is the description of the first cinema"
                        },
                        new cinema()
                        {
                            Name = "Cinema 3",
                            logoUrl = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            discription = "This is the description of the first cinema"
                        },
                        new cinema()
                        {
                            Name = "Cinema 4",
                            logoUrl = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            discription = "This is the description of the first cinema"
                        },
                        new cinema()
                        {
                            Name = "Cinema 5",
                            logoUrl = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            discription = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            Name = "Actor 1",
                            bio = "This is the Bio of the first actor",
                            picUrl = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Actor()
                        {
                            Name = "Actor 2",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 3",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 4",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            Name = "Actor 5",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            Name = "Producer 1",
                            bio = "This is the Bio of the first actor",
                            picUrl = "http://dotnethow.net/images/producers/producer-1.jpeg"

                        },
                        new Producer()
                        {
                            Name = "Producer 2",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 3",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 4",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            Name = "Producer 5",
                            bio = "This is the Bio of the second actor",
                            picUrl = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name = "Life",
                            Discription = "This is the Life movie description",
                            price = 39.50,
                            picUrl = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            startTime = DateTime.Now.AddDays(-10),
                            endTime = DateTime.Now.AddDays(10),
                            cinemaId = 3,
                            producerId = 3,
                            movieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "The Shawshank Redemption",
                            Discription = "This is the Shawshank Redemption description",
                            price = 29.50,
                            picUrl = "http://dotnethow.net/images/movies/movie-1.jpeg",
                            startTime = DateTime.Now,
                            endTime = DateTime.Now.AddDays(3),
                            cinemaId = 1,
                            producerId = 1,
                            movieCategory = MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name = "Ghost",
                            Discription = "This is the Ghost movie description",
                            price = 39.50,
                            picUrl = "http://dotnethow.net/images/movies/movie-4.jpeg",
                            startTime = DateTime.Now,
                            endTime = DateTime.Now.AddDays(7),
                            cinemaId = 4,
                            producerId = 4,
                            movieCategory = MovieCategory.Horror
                        },
                        new Movie()
                        {
                            Name = "Race",
                            Discription = "This is the Race movie description",
                            price = 39.50,
                            picUrl = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            startTime = DateTime.Now.AddDays(-10),
                            endTime = DateTime.Now.AddDays(-5),
                            cinemaId = 1,
                            producerId = 2,
                            movieCategory = MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name = "Scoob",
                            Discription = "This is the Scoob movie description",
                            price = 39.50,
                            picUrl = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            startTime = DateTime.Now.AddDays(-10),
                            endTime = DateTime.Now.AddDays(-2),
                            cinemaId = 1,
                            producerId = 3,
                            movieCategory = MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name = "Cold Soles",
                            Discription = "This is the Cold Soles movie description",
                            price = 39.50,
                            picUrl = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            startTime = DateTime.Now.AddDays(3),
                            endTime = DateTime.Now.AddDays(20),
                            cinemaId = 1,
                            producerId = 5,
                            movieCategory = MovieCategory.Drama
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Actors_movies.Any())
                {
                    context.Actors_movies.AddRange(new List<Actor_movie>()
                    {
                        new Actor_movie()
                        {
                            actorId = 1,
                            movieId = 1
                        },
                        new Actor_movie()
                        {
                            actorId = 3,
                            movieId = 1
                        },

                         new Actor_movie()
                        {
                            actorId = 1,
                             movieId = 2
                        },
                         new Actor_movie()
                        {
                            actorId = 4,
                             movieId = 2
                        },

                        new Actor_movie()
                        {
                            actorId = 1,
                            movieId = 3
                        },
                        new Actor_movie()
                        {
                            actorId = 2,
                            movieId = 3
                        },
                        new Actor_movie()
                        {
                            actorId = 5,
                            movieId = 3
                        },


                        new Actor_movie()
                        {
                            actorId = 2,
                            movieId = 4
                        },
                        new Actor_movie()
                        {
                            actorId = 3,
                            movieId = 4
                        },
                        new Actor_movie()
                        {
                            actorId = 4,
                            movieId = 4
                        },


                        new Actor_movie()
                        {
                            actorId = 2,
                            movieId = 5
                        },
                        new Actor_movie()
                        {
                            actorId = 3,
                            movieId = 5
                        },
                        new Actor_movie()
                        {
                            actorId = 4,
                            movieId = 5
                        },
                        new Actor_movie()
                        {
                            actorId = 5,
                            movieId = 5
                        },


                        new Actor_movie()
                        {
                            actorId = 3,
                            movieId = 6
                        },
                        new Actor_movie()
                        {
                            actorId = 4,
                            movieId = 6
                        },
                        new Actor_movie()
                        {
                            actorId = 5,
                            movieId = 6
                        },
                    });
                    context.SaveChanges();
                }

            }
        }

        public static async Task seedUserAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //roles
                var roleManger = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManger.RoleExistsAsync(UserRoles.Admin))
                    await roleManger.CreateAsync(new IdentityRole(UserRoles.Admin));

                if (!await roleManger.RoleExistsAsync(UserRoles.User))
                    await roleManger.CreateAsync(new IdentityRole(UserRoles.User));

                //users
                var userManger = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                //if this email as admin or not
                string adminEmail = "admin@Ecommerce.com";
                var adminUser = await userManger.FindByEmailAsync(adminEmail);
                if(adminUser == null)
                {
                    var newAdmin = new ApplicationUser()
                    {
                        FullName = "Admin_User",
                        UserName = "admin",
                        Email = adminEmail,
                        EmailConfirmed= true,
                    };
                    await userManger.CreateAsync(newAdmin, "CodeAdmin@123");
                    await userManger.AddToRoleAsync(newAdmin, UserRoles.Admin);
                }

                //users
                //if this email as user or not
                string UserEmail = "user@Ecommerce.com";
                var user = await userManger.FindByEmailAsync(UserEmail);
                if (user == null)
                {
                    var newuser = new ApplicationUser()
                    {
                        FullName = "Application_User",
                        UserName = "app-user",
                        Email = UserEmail,
                        EmailConfirmed = true,
                    };
                    await userManger.CreateAsync(newuser, "CodeAdmin@123");
                    await userManger.AddToRoleAsync(newuser, UserRoles.User);
                }
            }

        }
    }
}
