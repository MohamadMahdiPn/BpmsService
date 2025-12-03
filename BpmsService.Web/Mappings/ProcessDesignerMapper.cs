using BpmsService.Domain.Entities;
using BpmsService.Web.ViewModels;

namespace BpmsService.Web.Mappings;

public static class ProcessDesignerMapper
{
    public static ProcessDesignerVm ToDesignerVm(this ProcessDefinition process)
    {
        return new ProcessDesignerVm
        {
            Id = process.Id,
            Name = process.Name,
            Code = process.Code,
            Version = process.Version,
            IsActive = process.IsActive,
            Steps = process.Steps
                .OrderBy(s => s.Order)
                .Select(s => s.ToStepItemVm())
                .ToList(),
            Transitions = process.Steps
                .SelectMany(s => s.OutgoingTransitions)
                .Select(t => t.ToTransitionItemVm())
                .ToList()
        };
    }

    public static StepItemVm ToStepItemVm(this StepDefinition step)
    {
        return new StepItemVm
        {
            Id = step.Id,
            Name = step.Name,
            Order = step.Order,
            StepType = step.StepType,
            AssignedRole = step.AssignedRole
        };
    }

    public static TransitionItemVm ToTransitionItemVm(this Transition t)
    {
        return new TransitionItemVm
        {
            Id = t.Id,
            FromStepId = t.FromStepId,
            ToStepId = t.ToStepId,
            Name = t.Name
        };
    }
}
