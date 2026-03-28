using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace RESTDemo.Models.API;

public abstract class BaseResponse : IActionResult
{
    public abstract Task ExecuteResultAsync(ActionContext context);

}

public class PatientResponse : BaseResponse 
{
    private int Id { get; }
    public string Name { get; }
    public int Age { get; }
    public string City { get; }

    public PatientResponse(int id,string name = "John", int age = 20, string city = "New York")
    {
        Id = id;
        Name = name;
        Age = age;
        City = city;
    }
    
    public override async Task ExecuteResultAsync(ActionContext context)
    {
        context.HttpContext.Response.ContentType = "application/json";
        context.HttpContext.Response.StatusCode = 200;
        var jsonResponse = JsonSerializer.Serialize(this);
        await context.HttpContext.Response.WriteAsync(jsonResponse);
        
    }
}

public class BadRequestResponse : BaseResponse
{
    public string Type { get; set; } = "about:blank"; // Standardwert für generische Fehler
    public string Title { get; set; } = "Bad Request";
    public int Status { get; set; } = 400;
    public string Detail { get; set; }
    public string Instance { get; set; } // Optional, z. B. Pfad der fehlerhaften Anfrage
    
    public BadRequestResponse(string detail)
    {
        Detail = detail;
    }
    
    public override async Task ExecuteResultAsync(ActionContext context)
    {
        context.HttpContext.Response.ContentType = "application/problem+json"; // RFC 7807 Content-Type
        context.HttpContext.Response.StatusCode = Status;

        var response = new
        {
            type = Type,
            title = Title,
            status = Status,
            detail = Detail,
            instance = Instance
        };

        var jsonResponse = JsonSerializer.Serialize(response);
        await context.HttpContext.Response.WriteAsync(jsonResponse);
    }
}

