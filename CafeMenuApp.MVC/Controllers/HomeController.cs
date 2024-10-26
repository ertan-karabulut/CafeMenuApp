using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CafeMenuApp.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;

    public HomeController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    [Authorize]
    public async Task<IActionResult> Index(CancellationToken cancellationToken = default)
    {
        return View(await _categoryService.ProductCountAsync(cancellationToken));
    }
}
