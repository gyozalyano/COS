using COS.Models;
using COS.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace COS.Controllers;

public class DinnerController : Controller
{
    private IDinnerRepository _dinnerRepository;
    private ICategoryRepository _categoryRepository;

    public DinnerController(IDinnerRepository dinnerRepository, ICategoryRepository categoryRepository)
    {
        _dinnerRepository = dinnerRepository;
        _categoryRepository = categoryRepository;
    }

    public IActionResult Dinner()
    {
        var dinnerViewModel = new DinnerOptionsViewModel(_dinnerRepository.AllDinnerOptions, "Standard Menu");
        return View(dinnerViewModel);
    }
}