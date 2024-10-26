using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace CafeMenuApp.MVC.Controllers;

public class CustomerController : Controller
{
    private readonly IProductService _productService;
    private readonly IExchangeRateService _exchangeRateService;
    public CustomerController(IProductService productService, IExchangeRateService exchangeRateService)
    {
        _productService = productService;
        _exchangeRateService = exchangeRateService;
    }

    public async Task<IActionResult> List(CancellationToken cancellationToken = default)
    {
        var exchangeRates = await _exchangeRateService.GetExchangeRates(cancellationToken);
        var eur = exchangeRates.FirstOrDefault(x => x.CurrencyName.Contains("EURO"));
        var usd = exchangeRates.FirstOrDefault(x=>x.CurrencyName != eur.CurrencyName);
        var products = await _productService.CustomerListAsync(cancellationToken);
        var result = products.Select(x => new CustomerProductListViewModel
        {
            CategoryName = x.CategoryName,
            ImagePath = x.ImagePath,
            Name = x.Name,
            Price = x.Price,
            Properties = x.Properties,
            CreatedDate = x.CreatedDate,
            CreatorUserId = x.CreatorUserId,
            PriceEur = (x.Price / eur.ForexBuying),
            PriceUsd = (x.Price / usd.ForexBuying)
        }).ToList();
        return View(result);
    }
}
