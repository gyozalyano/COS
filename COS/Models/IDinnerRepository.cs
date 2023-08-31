namespace COS.Models;

public interface IDinnerRepository
{
    IEnumerable<Dinner> AllDinnerOptions { get; }
    Dinner? GetDinnerById(int dinnerId);
}