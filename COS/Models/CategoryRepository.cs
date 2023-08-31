namespace COS.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly CosDbContext _cosDbContext;

    public CategoryRepository(CosDbContext cosDbContext)
    {
        _cosDbContext = cosDbContext;
    }

    public IEnumerable<Category> AllCategories => _cosDbContext.Categories.OrderBy(d => d.CategoryName);
}