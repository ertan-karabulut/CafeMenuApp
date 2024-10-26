using CafeMenuApp.Application.DTO.Property;

namespace CafeMenuApp.MVC.Models;

public class CustomerProductListViewModel
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal PriceUsd { get; set; }
    public decimal PriceEur { get; set; }
    public string ImagePath { get; set; }
    public string CategoryName { get; set; }
    public DateTime? CreatedDate { get; set; }
    public Guid? CreatorUserId { get; set; }
    public List<ListPropertyResponseDto> Properties { get; set; }
}
