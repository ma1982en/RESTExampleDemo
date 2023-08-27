using Microsoft.AspNetCore.Mvc;
using RESTDemo.Contracts;
using RESTDemo.Models.Internal;
using RiskFirst.Hateoas;

namespace RESTDemo.Controllers.REST_3;

[ApiExplorerSettings(GroupName =Const.Level3Definition)]
[ApiController]
public class MedicalRecordController : ControllerBase
{
    private readonly IMedicalRecord _contextService;
    private readonly ILinksService _linksService;

    public MedicalRecordController(IMedicalRecord contextService, ILinksService linksService)
    {
        _contextService = contextService;
        _linksService = linksService;
    }
    
    [HttpPost("api/medicalRecord")]
    public IActionResult CreateMedicalRecord([FromBody] MedicalRecord medicalRecord)
    {
        _contextService.Add(medicalRecord);
        return Ok();
    }

    [HttpGet("api/medicalRecord/{mid}", Name = "GetModelRoute")]
    public async Task<IActionResult> GetMedicalRecord(int mid)
    {
        var medicalRecord = _contextService.Get(mid);
        await _linksService.AddLinksAsync(medicalRecord);
        return Ok(medicalRecord);
    }

    [HttpPut("api/medicalRecord/{mid}", Name = "UpdateModelsRoute")]
    public IActionResult UpdateMedicalRecord(int mid, [FromBody] MedicalRecord medicalRecord)
    {
        bool done = _contextService.Update(mid, medicalRecord);
        return Ok(done);
    }

    [HttpDelete("api/medicalRecord/{mid}", Name = "DeleteModelRoute")]
    public IActionResult DeleteMedicalRecord(int mid)
    {
        bool isSuccessfulDeleted = _contextService.Delete(mid);
        return Ok(isSuccessfulDeleted);
    }
}