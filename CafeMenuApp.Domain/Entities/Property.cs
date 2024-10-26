namespace CafeMenuApp.Domain.Entities;

public class Property
{
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }

    public ICollection<Product> Products { get; set; }
}
