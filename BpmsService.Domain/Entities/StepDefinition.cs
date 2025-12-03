using BpmsService.Domain.Enums;
using BpmsService.Domain.Interfaces;

namespace BpmsService.Domain.Entities;

public class StepDefinition:IBaseTable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;

    public Guid ProcessDefinitionId { get; set; }
    public ProcessDefinition ProcessDefinition { get; set; } = default!;

    public string Name { get; set; } = default!;
    public int Order { get; set; }
    public StepType StepType { get; set; }
    public string? AssignedRole { get; set; }

    public ICollection<Transition> OutgoingTransitions { get; set; } = new List<Transition>();
    public ICollection<Transition> IncomingTransitions { get; set; } = new List<Transition>();
}