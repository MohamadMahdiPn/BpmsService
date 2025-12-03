using System.ComponentModel.DataAnnotations;

namespace BpmsService.Domain.Interfaces;

public interface IBaseTable
{
    [Key]
    public Guid Id { get; set; }

    public bool IsActive { get; set; }
}