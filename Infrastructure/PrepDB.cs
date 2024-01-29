using Domain.Entiys;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class PrepDB
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        SeedData(context: serviceScope.ServiceProvider.GetService<ApplicationDbContext>());
    }

    public static void SeedData(ApplicationDbContext context)
    {
        Console.WriteLine("Appling Migrations...");

        context.Database.Migrate();


        if (!context.Users.Any())
        {
            Console.WriteLine("Adding some users - Seeding...");

            context.Users.AddRange(
                new User("AmirHosein", "Pa$$w0rd"),
                new User("NodeinSoft", "password"));
            context.SaveChanges();
        }
        if (!context.Products.Any())
        {
            Console.WriteLine("Adding some products - Seeding...");

            context.Products.AddRange(
                new Product("P1", DateTime.Now.AddDays(-1), "09390272620", "HSN@Gmail.com", true, 1),
                new Product("P2", DateTime.Now.AddDays(-1), "02190272620", "NodinSoft@Gmail.com", true, 2));
            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Already hav data - Not Seeding");
        }

        Console.WriteLine("Migration has ben made");
    }
}
