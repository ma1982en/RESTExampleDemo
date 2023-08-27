using Microsoft.AspNetCore.Mvc;
using RESTDemo.Contracts;
using RESTDemo.Models.Internal;

namespace RESTDemo.Controllers.REST_3;

[ApiExplorerSettings(GroupName =Const.Level3Definition)]
[ApiController]
public class MedicalRecordEntryController : ControllerBase
{
    private readonly IMedicalRecordEntry _medicalRecordEntry;

    public MedicalRecordEntryController(IMedicalRecordEntry medicalRecordEntry)
    {
        _medicalRecordEntry = medicalRecordEntry;
    }

    [HttpPost("api/medicalRecord/{mid}/medicalRecordEntry")]
    public IActionResult Create(int mid, [FromBody] MedicalRecordEntry medicalRecordEntry)
    {
        MedicalRecordEntry resultMedicalRecordEntry = _medicalRecordEntry.Add(mid, medicalRecordEntry);
        return Created(new Uri($"medicalRecord/{mid}/medicalRecordEntry"),resultMedicalRecordEntry);
    }
    
    [HttpGet("api/medicalRecord/{mid}/medicalRecordEntry{eid}")]
    public IActionResult Get(int mid, int eid)
    {
        var medicalRecordEntry = _medicalRecordEntry.Get(mid, eid);
        return Ok(medicalRecordEntry);
    }
    
    
    [HttpPut("api/medicalRecord/{mid}/medicalRecordEntry{eid}")]
    public IActionResult Update(int mid, int eid, [FromBody]MedicalRecordEntry medicalRecordEntry)
    {
        _medicalRecordEntry.Update(mid, eid,medicalRecordEntry);
        return Ok();
    }
    
    [HttpDelete("api/medicalRecord/{mid}/medicalRecordEntry{eid}")]
    public IActionResult Delete(int mid, int eid)
    {
        _medicalRecordEntry.Delete(mid, eid);
        return Ok();
    }
    
    
}