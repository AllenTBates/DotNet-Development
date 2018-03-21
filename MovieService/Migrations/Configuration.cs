namespace MovieService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MovieService.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieService.Models.MovieServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieService.Models.MovieServiceContext context)
        {
            context.Directors.AddOrUpdate(x => x.Id,
                new Director() { Id = 1, Name = "Guillermo Del Toro" },
                new Director() { Id = 2, Name = "Stephen Spielberg" },
                new Director() { Id = 3, Name = "Christopher Nolan" }
            );

            context.Movies.AddOrUpdate(x => x.Id,
                new Movie()
                {
                    Id = 1,
                    Title = "Shape of Water",
                    Year = 2017,
                    DirectorId = 1,
                    Genre = "Drama"
                },
                new Movie()
                {
                    Id = 2,
                    Title = "Saving Private Ryan",
                    Year = 1998,
                    DirectorId = 2,
                    Genre = "War"
                },
                new Movie()
                {
                    Id = 3,
                    Title = "The Dark Knight",
                    Year = 2008,
                    DirectorId = 1,
                    Genre = "Superhero"
                },
                new Movie()
                {
                    Id = 4,
                    Title = "Pacific Rim",
                    Year = 2013,
                    DirectorId = 1,
                    Genre = "Science-fiction"
                }
            );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
