using COS.Models;
using COS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace COS.Controllers;

public class HomeController : Controller
{
    private readonly IDinnerRepository _dinnerRepository;

    public HomeController(IDinnerRepository dinnerRepository)
    {
        _dinnerRepository = dinnerRepository;
    }

    public IActionResult Index()
    {
        var dinnersOfTheWeek = _dinnerRepository.AllDinnerOptions;
        var homeViewModel = new HomeViewModel(dinnersOfTheWeek);
        return View(homeViewModel);
    }
}