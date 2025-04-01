using QuanLyNhanLuc.Models.Enums;

namespace QuanLyNhanLuc.Models;

public class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Status Status { get; set; } = Status.Approved;
    public DateTime Created { get; set; } = DateTime.Now;


}
