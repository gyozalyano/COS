using Microsoft.EntityFrameworkCore;

namespace COS.Models;

public class DbInitializer
{
    public static void Seed(IApplicationBuilder applicationBuilder)
    {
        var context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider
            .GetRequiredService<CosDbContext>();

        if (!context.Categories.Any())
        {
            context.Categories.AddRange(Categories.Select(c => c.Value));
        }

        if (context.DinnerOptions.Any())
        {
            context.DinnerOptions.ExecuteDelete();
            context.SaveChanges();
        }

        if (!context.DinnerOptions.Any())
        {
            context.AddRange
            (
                new Dinner
                {
                    Name = "Dolma",
                    Description = "The ultimate cabbage rolls filled with meet, rice and herbs.",
                    Category = Categories["Standard"],
                    ImageUrl = "https://i.imgur.com/7JbWpS8.jpg",
                    AllergyInformation = ""
                },

                new Dinner
                {
                    Name = "Risotto",
                    Description = "Risotto rice cooked with chorizo and a variety of vegetables.",
                    Category = Categories["Standard"],
                    ImageUrl = "https://i.imgur.com/gmMqTVz.jpg",
                    AllergyInformation = ""
                },

                new Dinner
                {
                    Name = "Baked Gnocchi",
                    Description = "Fresh gnocchi baked with chorizo, peppers, spinach, sun-dried tomatoes and cheese.",
                    Category = Categories["Standard"],
                    ImageUrl = "https://i.imgur.com/hd4vuMm.jpg",
                    AllergyInformation = " "
                },

                new Dinner
                {
                    Name = "Lasagna",
                    Description = "Fresh lasagna sheets with outdoor breed beef mince and a variety of vegetables.",
                    Category = Categories["Standard"],
                    ImageUrl = "https://i.imgur.com/eKlZ6LO.jpg",
                    AllergyInformation = ""
                }

                //new Dinner
                //{
                //    Name = "Risotto",
                //    Description = "",
                //    Category = Categories["Standard"],
                //    ImageUrl = "https://i.imgur.com/gmMqTVz.jpg",
                //    AllergyInformation = ""
                //},

                //new Dinner
                //{
                //    Name = "Risotto",
                //    Description = "",
                //    Category = Categories["Standard"],
                //    ImageUrl =
                //        "https://i.imgur.com/gmMqTVz.jpg",
                //    AllergyInformation = ""
                //}
            );
        }

        context.SaveChanges();
    }

    private static Dictionary<string, Category>? _categories;

    public static Dictionary<string, Category> Categories
    {
        get
        {
            if (_categories == null)
            {
                var allCategories = new Category[]
                {
                        new() { CategoryName = "Standard" },
                        new() { CategoryName = "Vegetarian" }
                };

                _categories = new Dictionary<string, Category>();

                foreach (var category in allCategories)
                {
                    _categories.Add(category.CategoryName, category);
                }
            }

            return _categories;
        }
    }
}