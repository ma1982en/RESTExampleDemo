using FreeMediator;

namespace RESTDemo.Models.API;

public record PatientQuery : IRequest<BaseResponse>
{
    public int Id { get; set; }
}