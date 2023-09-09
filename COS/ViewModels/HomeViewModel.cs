using COS.Models;

namespace COS.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Dinner> DinnersOfTheWeek { get; set; }

    public HomeViewModel(IEnumerable<Dinner> dinnersOfTheWeek)
    {
        DinnersOfTheWeek = dinnersOfTheWeek;
    }
}