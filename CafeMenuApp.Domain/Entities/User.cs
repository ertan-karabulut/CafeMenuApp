using CafeMenuApp.Domain.Entities.Base;

namespace CafeMenuApp.Domain.Entities;
public class User : BaseEntity
{
    public string Name { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; }
    public string HasPassword { get; set; }
    public string SaltPassword { get; set; }
}
