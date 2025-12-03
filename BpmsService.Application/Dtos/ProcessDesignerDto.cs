using BpmsService.Domain.Enums;

namespace BpmsService.Application.Dtos;

public class ProcessDesignerDto
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int Version { get; set; } = 1;
    public bool IsActive { get; set; } = true;

    public List<StepDto> Steps { get; set; } = new();
    public List<TransitionDto> Transitions { get; set; } = new();
}

public class StepDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Order { get; set; }
    public StepType StepType { get; set; }
    public string? AssignedRole { get; set; }
}

public class TransitionDto
{
    public Guid Id { get; set; }
    public Guid FromStepId { get; set; }
    public Guid ToStepId { get; set; }
    public string Name { get; set; } = default!;
}

public class NewStepDto
{
    public string Name { get; set; } = default!;
    public int Order { get; set; }
    public StepType StepType { get; set; } = StepType.UserTask;
    public string? AssignedRole { get; set; }
}

public class NewTransitionDto
{
    public Guid FromStepId { get; set; }
    public Guid ToStepId { get; set; }
    public string Name { get; set; } = default!;
}