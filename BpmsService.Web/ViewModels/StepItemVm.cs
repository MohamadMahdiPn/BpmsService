using BpmsService.Domain.Enums;

namespace BpmsService.Web.ViewModels;

public class StepItemVm
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public int Order { get; set; }
    public StepType StepType { get; set; }
    public string? AssignedRole { get; set; }
}