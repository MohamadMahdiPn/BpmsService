using BpmsService.Domain.Enums;
using BpmsService.Domain.Interfaces;

namespace BpmsService.Domain.Entities;

public class ProcessInstance : IBaseTable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;


    public Guid ProcessDefinitionId { get; set; }
    public ProcessDefinition ProcessDefinition { get; set; } = default!;

    public string StartedByUserId { get; set; } = default!;
    public DateTime StartedAt { get; set; }
    public ProcessInstanceStatus Status { get; set; }

    public ICollection<StepInstance> Steps { get; set; } = new List<StepInstance>();
    public ICollection<FormData> Forms { get; set; } = new List<FormData>();
}