using BpmsService.Domain.Interfaces;
using System.Transactions;

namespace BpmsService.Domain.Entities;

public class ProcessDefinition:IBaseTable
{
 
    public Guid Id { get; set; } = Guid.NewGuid();
    public bool IsActive { get; set; }


    public string Name { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int Version { get; set; }

    public ICollection<StepDefinition> Steps { get; set; } = new List<StepDefinition>();
}