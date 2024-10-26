namespace CafeMenuApp.Domain.Entities.Base;
public class BaseEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsDeleted { get; set; }
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    public Guid? CreatorUserId { get; set; }
}
