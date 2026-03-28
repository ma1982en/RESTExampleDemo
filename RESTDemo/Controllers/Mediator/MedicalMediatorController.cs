using FreeMediator;
using Microsoft.AspNetCore.Mvc;
using RESTDemo.Models.API;
using RESTDemo.Models.Internal;

namespace RESTDemo.Controllers.Mediator;

[ApiExplorerSettings(GroupName = Const.LevelMediatorDefinition)]
[ApiController]
public class MedicalMediatorController : Controller
{
    private readonly IMediator _mediator;

    public MedicalMediatorController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("api/patients/{id:int}")]
    public async Task<BaseResponse> GetPatient(int id,CancellationToken cancellationToken)
    {
        return await _mediator.Send(new PatientQuery{Id = id}, cancellationToken);
    }
}