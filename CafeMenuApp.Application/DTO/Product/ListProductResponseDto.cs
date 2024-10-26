using CafeMenuApp.Application.DTO.Property;

namespace CafeMenuApp.Application.DTO.Product;

public class ListProductResponseDto : BaseDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }
    public string CategoryName { get; set; }
    public List<ListPropertyResponseDto> Properties { get; set; }
}
