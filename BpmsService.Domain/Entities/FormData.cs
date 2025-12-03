using BpmsService.Domain.Interfaces;

namespace BpmsService.Domain.Entities;

public class FormData : IBaseTable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;
    
    public Guid ProcessInstanceId { get; set; }
    public ProcessInstance ProcessInstance { get; set; } = default!;

    public string DataJson { get; set; } = "{}";
}