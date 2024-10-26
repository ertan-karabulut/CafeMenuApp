namespace CafeMenuApp.Application.DTO.ExchangeRate;

public class ServiceExcehangeRateResponse
{
    public List<TCMBExchangeRate> TCMB_AnlikKurBilgileri { get; set; }
}

public class TCMBExchangeRate
{
    public string Isim { get; set; }
    public decimal ForexBuying { get; set; }
}
