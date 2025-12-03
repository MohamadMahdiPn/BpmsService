namespace BpmsService.Web.ViewModels;

public class ProcessDesignerVm
{
    public Guid? Id { get; set; }
    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int Version { get; set; } = 1;
    public bool IsActive { get; set; } = true;

    public List<StepItemVm> Steps { get; set; } = new();
    public List<TransitionItemVm> Transitions { get; set; } = new();
}