using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ButtonManufacture.Data;
using System;
using System.Linq;

namespace ButtonManufacture.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ButtonManufactureContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ButtonManufactureContext>>()))
            {
                // Look for any movies.
                if (context.Button.Any())
                {
                    return;   // DB has been seeded
                }

                context.Button.AddRange(
                    new Button
                    {
                        Type = "Flat",
                        ManufacturingDate = DateTime.Parse("1989-2-12"),
                        color = "red",
                        Price = 2,
                        Quantity = 4,
                        Review = 8
                    },

                    new Button
                    {
                        Type = "Lapel",
                        ManufacturingDate = DateTime.Parse("1999-2-22"),
                        color = "Green",
                        Price = 3,
                        Quantity = 6,
                        Review = 7
                    },

                    new Button
                    {
                        Type = "Shank",
                        ManufacturingDate = DateTime.Parse("2000-6-02"),
                        color = "White",
                        Price = 6,
                        Quantity = 1,
                        Review = 9
                    },

                    new Button
                    {
                        Type = "Metal",
                        ManufacturingDate = DateTime.Parse("2001-7-13"),
                        color = "red",
                        Price = 4,
                        Quantity = 5,
                        Review = 8
                    }
                );
                context.SaveChanges();
            }
        }
    }
}