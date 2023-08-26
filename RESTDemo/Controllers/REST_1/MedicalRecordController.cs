using Microsoft.AspNetCore.Mvc;
using RESTDemo.Models.Internal;

namespace RESTDemo.Controllers.REST_1;

[ApiExplorerSettings(GroupName =Const.Level1Definition)]
[ApiController]
public class MedicalRecordController : ControllerBase
{
    [HttpPost("medicalRecord/create")]
    public IActionResult CreateMedicalRecord([FromBody] string medicalRecord)
    {
        return Ok();
    }

    [HttpGet("medicalRecord/{mid}/get")]
    public IActionResult GetMedicalRecord(int mid)
    {
        return Ok();
    }

    [HttpPost("medicalRecord/{mid}/update")]
    public IActionResult UpdateMedicalRecord(int mid, [FromBody] string medicalRecord)
    {
        return Ok();
    }

    [HttpPost("medicalRecord/{mid}/delete")]
    public IActionResult DeleteMedicalRecord(int mid)
    {
        return Ok();
    }
    
    
    [HttpPost("medicalRecord/{mid}/entry/create")]
    public IActionResult CreateMedicalRecordEntry(int mid,[FromBody] string medicalRecord)
    {
        return Ok();
    }
    
    
    [HttpPost("medicalRecord/{mid}/entry/{eid}/document/create")]
    public IActionResult CreateMedicalRecordEntry(int mid,int eid,[FromBody] string medicalRecordEntry)
    {
        return Ok();
    }
    
    [HttpPost("medicalRecord/{mid}/patient/create")]
    public IActionResult CreatePatient(int mid,[FromBody] string patient)
    {
        return Ok();
    }
    
    [HttpPost("medicalRecord/{mid}/patient/{pid}/address/create")]
    public IActionResult CreatePatientAddress(int mid,int pid,[FromBody] string patientAddress)
    {
        return Ok();
    }
    

    
}