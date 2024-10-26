using CafeMenuApp.Application.DTO.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeMenuApp.Application.Interface.Infrastructure.Service;
public interface IExchangeRateService
{
    Task<List<ListExchangrRateResponseDto>> GetExchangeRates(CancellationToken cancellationToken = default);
}
