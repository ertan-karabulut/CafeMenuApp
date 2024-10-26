using CafeMenuApp.Application.DTO.ExchangeRate;
using CafeMenuApp.Application.Interface.Infrastructure.Service;
using System.Text.Json;

namespace CafeMenuApp.Infrastructure.Service;

public class ExchangeRateService : IExchangeRateService
{
    private readonly HttpClient _httpClient;
    public ExchangeRateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ListExchangrRateResponseDto>> GetExchangeRates(CancellationToken cancellationToken = default)
    {
        var result = new List<ListExchangrRateResponseDto>();
        var httpResponse = await _httpClient.GetAsync("https://hasanadiguzel.com.tr/api/kurgetir", cancellationToken);

        if (httpResponse == null)
        {
            throw new HttpRequestException("Response is null");
        }
        string response = await httpResponse.Content.ReadAsStringAsync(cancellationToken);
        if (httpResponse.IsSuccessStatusCode)
        {
            ServiceExcehangeRateResponse tResponse = JsonSerializer.Deserialize<ServiceExcehangeRateResponse>(response, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });


            result = tResponse.TCMB_AnlikKurBilgileri.Where(x=>x.Isim == "ABD DOLARI" || x.Isim == "EURO").Select(x => new ListExchangrRateResponseDto
            {
                ForexBuying = x.ForexBuying,
                CurrencyName = x.Isim
            }).ToList();
        }

        return result;
    }
}
