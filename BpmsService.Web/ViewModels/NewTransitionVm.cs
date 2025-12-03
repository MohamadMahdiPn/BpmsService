namespace BpmsService.Web.ViewModels;

public class NewTransitionVm
{
    public Guid FromStepId { get; set; }
    public Guid ToStepId { get; set; }
    public string Name { get; set; } = default!;
}