using BpmsService.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BpmsService.Domain.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    :IdentityDbContext<ApplicationUser,ApplicationRole,Guid>(options)
{
    public DbSet<ProcessDefinition> ProcessDefinitions => Set<ProcessDefinition>();
    public DbSet<StepDefinition> StepDefinitions => Set<StepDefinition>();
    public DbSet<Transition> Transitions => Set<Transition>();

    public DbSet<ProcessInstance> ProcessInstances => Set<ProcessInstance>();
    public DbSet<StepInstance> StepInstances => Set<StepInstance>();
    public DbSet<FormData> FormsData => Set<FormData>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Transitionها
        modelBuilder.Entity<StepDefinition>()
            .HasMany(s => s.OutgoingTransitions)
            .WithOne(t => t.FromStep)
            .HasForeignKey(t => t.FromStepId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<StepDefinition>()
            .HasMany(s => s.IncomingTransitions)
            .WithOne(t => t.ToStep)
            .HasForeignKey(t => t.ToStepId)
            .OnDelete(DeleteBehavior.NoAction);

      
        modelBuilder.Entity<ProcessDefinition>()
            .HasMany(p => p.Steps)
            .WithOne(s => s.ProcessDefinition)
            .HasForeignKey(s => s.ProcessDefinitionId)
            .OnDelete(DeleteBehavior.Restrict); // ❗ بهتره این هم Cascade نباشه

      
     
        modelBuilder.Entity<StepInstance>()
            .HasOne(si => si.ProcessInstance)
            .WithMany(pi => pi.Steps)
            .HasForeignKey(si => si.ProcessInstanceId)
            .OnDelete(DeleteBehavior.Cascade); // فقط این مسیر cascade داشته باشه

     
    }

}