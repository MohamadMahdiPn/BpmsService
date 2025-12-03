using BpmsService.Domain.Enums;
using BpmsService.Domain.Interfaces;

namespace BpmsService.Domain.Entities;

public class StepInstance : IBaseTable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;


    public Guid ProcessInstanceId { get; set; }
    public ProcessInstance ProcessInstance { get; set; } = default!;

    public Guid StepDefinitionId { get; set; }
    public StepDefinition StepDefinition { get; set; } = default!;

    public string? AssignedToUserId { get; set; }
    public StepInstanceStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
}