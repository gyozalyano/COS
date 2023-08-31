using Microsoft.EntityFrameworkCore;

namespace COS.Models;

public class DinnerRepository : IDinnerRepository
{
    private readonly CosDbContext _cosDbContext;

    public DinnerRepository(CosDbContext cosDbContext)
    {
        _cosDbContext = cosDbContext;
    }

    public IEnumerable<Dinner> AllDinnerOptions => _cosDbContext.DinnerOptions.Include(c => c.Category);

    public Dinner? GetDinnerById(int dinnerId) => _cosDbContext.DinnerOptions.FirstOrDefault(d => d.DinnerId == dinnerId);
}