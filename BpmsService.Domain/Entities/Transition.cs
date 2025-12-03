using BpmsService.Domain.Interfaces;

namespace BpmsService.Domain.Entities;

public class Transition:IBaseTable
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; } = true;


    public Guid FromStepId { get; set; }
    public StepDefinition FromStep { get; set; } = default!;

    public Guid ToStepId { get; set; }
    public StepDefinition ToStep { get; set; } = default!;

    public string Name { get; set; } = default!;
    public string? ConditionJson { get; set; }
}