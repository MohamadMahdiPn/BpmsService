using BpmsService.Domain.Data;
using BpmsService.Domain.Entities;
using BpmsService.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BpmsService.Infrastructure.Implementations;

public class ProcessDefinitionService : IProcessDefinitionService
{
    private readonly ApplicationDbContext _db;
    private DbSet<ProcessDefinition> _processDefinitions;

    public ProcessDefinitionService(ApplicationDbContext db)
    {
        _db = db;
        _processDefinitions = _db.Set<ProcessDefinition>();
    }


    public async Task<ProcessDesignerVm?> GetDesignerAsync(Guid id)
    {
        var process = await _db.ProcessDefinitions
            .Include(p => p.Steps)
                .ThenInclude(s => s.OutgoingTransitions)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (process == null)
            return null;

        return process.ToDesignerVm();
    }

    public Task<ProcessDesignerVm> CreateNewDesignerAsync()
    {
        var vm = new ProcessDesignerVm
        {
            Version = 1,
            IsActive = true
        };

        return Task.FromResult(vm);
    }

    public async Task<Guid> SaveProcessAsync(ProcessDesignerVm vm)
    {
        ProcessDefinition entity;

        if (vm.Id == null || vm.Id == Guid.Empty)
        {
            entity = new ProcessDefinition
            {
                Id = Guid.NewGuid(),
                Name = vm.Name,
                Code = vm.Code,
                Version = vm.Version,
                IsActive = vm.IsActive
            };

            _db.ProcessDefinitions.Add(entity);
        }
        else
        {
            entity = await _db.ProcessDefinitions
                .FirstAsync(p => p.Id == vm.Id.Value);

            entity.Name = vm.Name;
            entity.Code = vm.Code;
            entity.Version = vm.Version;
            entity.IsActive = vm.IsActive;
        }

        await _db.SaveChangesAsync();
        return entity.Id;
    }

    public async Task AddStepAsync(Guid processId, NewStepVm newStep)
    {
        var process = await _db.ProcessDefinitions
            .Include(p => p.Steps)
            .FirstAsync(p => p.Id == processId);

        var order = newStep.Order;
        if (order == 0)
        {
            order = process.Steps.Any()
                ? process.Steps.Max(s => s.Order) + 1
                : 1;
        }

        var step = new StepDefinition
        {
            Id = Guid.NewGuid(),
            ProcessDefinitionId = process.Id,
            Name = newStep.Name,
            Order = order,
            StepType = newStep.StepType,
            AssignedRole = newStep.AssignedRole
        };

        _db.StepDefinitions.Add(step);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteStepAsync(Guid processId, Guid stepId)
    {
        // می‌تونی برای اطمینان از processId هم استفاده کنی، فعلاً ساده:
        var step = await _db.StepDefinitions
            .FirstOrDefaultAsync(s => s.Id == stepId);

        if (step != null)
        {
            _db.StepDefinitions.Remove(step);
            await _db.SaveChangesAsync();
        }
    }

    public async Task AddTransitionAsync(Guid processId, Transition newTransition)
    {
        _db.Transitions.Add(newTransition);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteTransitionAsync(Guid processId, Guid transitionId)
    {
        var t = await _db.Transitions
            .FirstOrDefaultAsync(x => x.Id == transitionId);

        if (t != null)
        {
            _db.Transitions.Remove(t);
            await _db.SaveChangesAsync();
        }
    }
}