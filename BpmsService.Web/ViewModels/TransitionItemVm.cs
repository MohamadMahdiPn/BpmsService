namespace BpmsService.Web.ViewModels;

public class TransitionItemVm
{
    public Guid Id { get; set; }
    public Guid FromStepId { get; set; }
    public Guid ToStepId { get; set; }
    public string Name { get; set; } = default!;
}