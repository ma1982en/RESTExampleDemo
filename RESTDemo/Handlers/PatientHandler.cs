using FreeMediator;
using RESTDemo.Models.API;

namespace RESTDemo.Handlers;

public class PatientHandler : IRequestHandler<PatientQuery, BaseResponse>
{
    public Task<BaseResponse> Handle(PatientQuery patientQuery, CancellationToken cancellationToken)
    {
        return Task.FromResult(new PatientResponse(patientQuery.Id) as BaseResponse);
    }
}