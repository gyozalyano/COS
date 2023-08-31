namespace COS.Models;

public interface ICategoryRepository
{
    IEnumerable<Category> AllCategories { get; }
}