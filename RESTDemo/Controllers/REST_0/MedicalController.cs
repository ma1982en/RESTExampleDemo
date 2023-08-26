using Microsoft.AspNetCore.Mvc;
using RESTDemo.Models.Internal;

namespace RESTDemo.Controllers.REST_0;


[ApiExplorerSettings(GroupName =Const.Level0Definition)]
[ApiController]
public class MedicalController : ControllerBase
{
    [Consumes("text/plain")]
    [HttpPost("patientData")]
    public IActionResult Post([FromBody]string content)
    {        
        return Ok($"Data Result: {content}");
    }
}