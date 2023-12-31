﻿using Microsoft.AspNetCore.Mvc;
using RESTDemo.Contracts;
using RESTDemo.Models.Internal;

namespace RESTDemo.Controllers.REST_2;

[ApiExplorerSettings(GroupName =Const.Level2Definition)]
[ApiController]
public class MedicalRecordController : ControllerBase
{
    private readonly IMedicalRecord _contextService;

    public MedicalRecordController(IMedicalRecord contextService)
    {
        _contextService = contextService;
    }
    
    [HttpPost("medicalRecord")]
    public IActionResult CreateMedicalRecord([FromBody] MedicalRecord medicalRecord)
    {
        _contextService.Add(medicalRecord);
        return Ok();
    }

    [HttpGet("medicalRecord/{mid}")]
    public IActionResult GetMedicalRecord(int mid)
    {
        var medicalRecord = _contextService.Get(mid);
        return Ok(medicalRecord);
    }

    [HttpPut("medicalRecord/{mid}")]
    public IActionResult UpdateMedicalRecord(int mid, [FromBody] MedicalRecord medicalRecord)
    {
        bool done = _contextService.Update(mid, medicalRecord);
        return Ok(done);
    }

    [HttpDelete("medicalRecord/{mid}")]
    public IActionResult DeleteMedicalRecord(int mid)
    {
        bool isSuccessfulDeleted = _contextService.Delete(mid);
        return Ok(isSuccessfulDeleted);
    }
}