using BpmsService.Domain.Entities;

namespace BpmsService.Infrastructure.Interfaces;

public interface IProcessDefinitionService
{
    Task<ProcessDefinition?> GetByIdAsync(Guid id);
}