using CafeMenuApp.Domain.Entities.Base;

namespace CafeMenuApp.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImagePath { get; set; }

    public Category Category { get; set; }
    public Guid CategoryId { get; set; }
    public ICollection<Property> Properties { get; set; }
}
