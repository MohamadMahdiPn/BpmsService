using BpmsService.Domain.Entities;
using BpmsService.Infrastructure.Interfaces;
using BpmsService.Web.Mappings;
using BpmsService.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BpmsService.Web.Pages.Processes
{
    public class DesignerModel : PageModel
    {
        #region Constructor

        private readonly IProcessDefinitionService _processDefinitionService;
        private readonly ILogger<DesignerModel> _logger;

        public DesignerModel(IProcessDefinitionService processDefinitionService, ILogger<DesignerModel> logger)
        {
            _processDefinitionService = processDefinitionService;
            _logger = logger;
        }

        #endregion


        #region Parameters

        [BindProperty]
        public ProcessDesignerVm Process { get; set; } = new();

        [BindProperty]
        public NewStepVm NewStep { get; set; } = new();

        [BindProperty]
        public NewTransitionVm NewTransition { get; set; } = new();

        #endregion




        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                Process = await _processDefinitionService.CreateNewDesignerAsync();
                return Page();
            }

            var process = await _processDefinitionService.GetByIdAsync(id.Value);

            if (process == null)
                return NotFound();

            Process = process.ToDesignerVm();
            return Page();
        }

        public async Task<IActionResult> OnPostSaveProcessAsync()
        {
            if (!ModelState.IsValid)
            {
                await ReloadListsAsync();
                return Page();
            }

            ProcessDefinition entity;
            if (Process.Id == null || Process.Id == Guid.Empty)
            {
                entity = new ProcessDefinition
                {
                    Id = Guid.NewGuid(),
                    Name = Process.Name,
                    Code = Process.Code,
                    Version = Process.Version,
                    IsActive = Process.IsActive
                };

                _db.ProcessDefinitions.Add(entity);
            }
            else
            {
                entity = await _processDefinitionService.GetByIdAsync(Process.Id.Value);

                entity.Name = Process.Name;
                entity.Code = Process.Code;
                entity.Version = Process.Version;
                entity.IsActive = Process.IsActive;
            }
        }
    }
}
