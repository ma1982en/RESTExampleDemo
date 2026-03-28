using FreeMediator;
using RESTDemo.Models.API;

namespace RESTDemo.Validations;

public class  ValidationBehavior: IPipelineBehavior<PatientQuery, BaseResponse> 
{
    public async Task<BaseResponse> Handle(PatientQuery request, RequestHandlerDelegate<BaseResponse> next, CancellationToken cancellationToken)
    {
        var validationErrors = new List<string>();
        if (request.Id <=0)
        {
            validationErrors.Add("ID muss größer als 0 sein.");
        }
        if (validationErrors.Count > 0)
        {
            return new BadRequestResponse(string.Join(Environment.NewLine, validationErrors));
        }
        
        return await next(cancellationToken);
    }
}