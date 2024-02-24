using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;
using System;

namespace RazorPageMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovieContext(
            serviceProvider.GetRequiredService<
              DbContextOptions<RazorPageMovieContext>>()))
            { 
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentException("Null RazorPageMovieContext");
                }
                //Para mirar cualquier pelicula
                if (context.Movie.Any())
                {
                    return; //DB muestra todo lo que contiene la clase 
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        General = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "GhostBusters",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        General = "Comedy",
                        Price = 8.99M,
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "GhostBusters",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        General = "Comedy",
                        Price = 9.99M,
                        Rating = "G"
                    },
                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        General = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }

                    );
                context.SaveChanges();
            }
        }

    }
}
