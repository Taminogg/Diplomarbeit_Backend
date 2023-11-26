using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class ChecklistsController : ControllerBase
{
    private readonly ChecklistService _checklistService;
    public ChecklistsController(ChecklistService checklistService) => _checklistService = checklistService;

    [HttpGet]
    public List<ChecklistDto> GetAllChecklists()
    {
        return _checklistService.GetAllChecklists();
    }

    [HttpGet("GetChecklistWithId/{id}")]
    public ChecklistDto GetChecklistWithId(int id)
    {
        return _checklistService.GetChecklistWithId(id);
    }

    [HttpPost("AddNewChecklist")]
    public ChecklistDto AddNewChecklist(AddChecklistDto addChecklistDto)
    {
        return _checklistService.AddNewChecklist(addChecklistDto);
    }

    [HttpPut("EditChecklist")]
    public ChecklistDto EditChecklist(ChecklistDto checklistDto)
    {
        return _checklistService.EditChecklist(checklistDto);
    }

    [HttpDelete("DeleteChecklist")]
    public ChecklistDto DeleteChecklist(int id)
    {
        return _checklistService.DeleteChecklist(id);
    }
}