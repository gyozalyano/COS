using COS.Models;

namespace COS.ViewModels;

public class DinnerOptionsViewModel
{
    public IEnumerable<Dinner> DinnerOptions { get; }
    public string? CurrentCategory { get; }

    public DinnerOptionsViewModel(IEnumerable<Dinner> allDinnerOptions, string? currentCategory)
    {
        DinnerOptions = allDinnerOptions;
        CurrentCategory = currentCategory;
    }
}