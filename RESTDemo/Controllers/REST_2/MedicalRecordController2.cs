using Microsoft.AspNetCore.Mvc;
using RESTDemo.Models.Internal;

namespace RESTDemo.Controllers.REST_2;

[ApiExplorerSettings(GroupName =Const.Level2Definition)]
[ApiController]
public class MedicalRecordController2 : ControllerBase
{
    [HttpPost("medicalRecord")]
    public IActionResult CreateMedicalRecord([FromBody] string medicalRecord)
    {
        return Ok();
    }

    [HttpGet("medicalRecord/{mid}")]
    public IActionResult GetMedicalRecord(int mid)
    {
        return Ok();
    }

    [HttpPut("medicalRecord/{mid}")]
    public IActionResult UpdateMedicalRecord(int mid, [FromBody] string medicalRecord)
    {
        return Ok();
    }

    [HttpDelete("medicalRecord/{mid}")]
    public IActionResult DeleteMedicalRecord(int mid)
    {
        return Ok();
    }
}