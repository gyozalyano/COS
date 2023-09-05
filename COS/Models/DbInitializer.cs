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

        if (context.Categories.Any())
        {
            context.RemoveRange();
        }

        if (!context.DinnerOptions.Any())
        {
            context.AddRange
                (
                    new Dinner
                    {
                        Name = "Dolma Jan2",
                        Description = "The ultimate cabbage rolls filled with meet, rice and herbs",
                        Category = Categories["Standard"],
                        ImageUrl =
                            "https://i.imgur.com/GLR0JI5.jpg",
                        ImageThumbnailUrl =
                            "https://i.imgur.com/GLR0JI5.jpg",
                        AllergyInformation = ""
                    },

                    new Dinner
                    {
                        Name = "Pizza",
                        Description = "The ultimate cabbage rolls filled with meet, rice and herbs",
                        Category = Categories["Standard"],
                        ImageUrl =
                            "https://photos.app.goo.gl/Mk52ikrhcZc8KbFX9",
                        ImageThumbnailUrl =
                            "https://photos.app.goo.gl/Mk52ikrhcZc8KbFX9",
                        AllergyInformation = ""
                    }
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