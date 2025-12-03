using BpmsService.Domain.Enums;

namespace BpmsService.Web.ViewModels;

public class NewStepVm
{
    public string Name { get; set; } = default!;
    public int Order { get; set; }
    public StepType StepType { get; set; } = StepType.UserTask;
    public string? AssignedRole { get; set; }
}