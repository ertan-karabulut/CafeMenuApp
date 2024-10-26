using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CafeMenuApp.MVC.Controllers
{
    public class ExchangeRateController : Controller
    {
        private readonly IExchangeRateService _exchangeRateService;
        public ExchangeRateController(IExchangeRateService exchangeRateService)
        {
            _exchangeRateService = exchangeRateService;
        }

        public async Task<IActionResult> ListAsyncJson()
        {
            return Json(await _exchangeRateService.GetExchangeRates());
        }
    }
}
