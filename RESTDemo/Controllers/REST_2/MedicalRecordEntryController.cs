﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RESTDemo.Contracts;
using RESTDemo.Models.Internal;

namespace RESTDemo.Controllers.REST_2;

[ApiExplorerSettings(GroupName =Const.Level2Definition)]
[ApiController]
public class MedicalRecordEntryController : ControllerBase
{
    private readonly IMedicalRecordEntry _medicalRecordEntry;

    public MedicalRecordEntryController(IMedicalRecordEntry medicalRecordEntry)
    {
        _medicalRecordEntry = medicalRecordEntry;
    }

    [HttpPost("medicalRecord/{mid}/medicalRecordEntry")]
    public IActionResult Create(int mid, [FromBody] MedicalRecordEntry medicalRecordEntry)
    {
        MedicalRecordEntry resultMedicalRecordEntry = _medicalRecordEntry.Add(mid, medicalRecordEntry);
        return Created(new Uri($"medicalRecord/{mid}/medicalRecordEntry"),resultMedicalRecordEntry);
    }
    
    [HttpGet("medicalRecord/{mid}/medicalRecordEntry{eid}")]
    public IActionResult Get(int mid, int eid)
    {
        var medicalRecordEntry = _medicalRecordEntry.Get(mid, eid);
        return Ok(medicalRecordEntry);
    }
    
    
    [HttpPut("medicalRecord/{mid}/medicalRecordEntry{eid}")]
    public IActionResult Update(int mid, int eid, [FromBody]MedicalRecordEntry medicalRecordEntry)
    {
        _medicalRecordEntry.Update(mid, eid,medicalRecordEntry);
        return Ok();
    }
    
    [HttpDelete("medicalRecord/{mid}/medicalRecordEntry{eid}")]
    public IActionResult Delete(int mid, int eid)
    {
        _medicalRecordEntry.Delete(mid, eid);
        return Ok();
    }
    
    
}