using FreeMediator;
using Microsoft.OpenApi;
using RESTDemo;
using RESTDemo.Contracts;
using RESTDemo.Handlers;
using RESTDemo.Models.API;
using RESTDemo.Models.Internal;
using RESTDemo.Services;
using RESTDemo.Validations;
using RiskFirst.Hateoas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLinks(config =>
{
    config.AddPolicy<MedicalRecord>(policy => {
        policy
            .RequireSelfLink()
            .RequireRoutedLink("update", "UpdateModelsRoute", x=> new { mid = x.Id})
            .RequireRoutedLink("delete", "DeleteModelRoute", x => new { mid = x.Id });
    });
});

builder.Services.AddSingleton<IMedicalRecord, MedicalRecordHandler>();

builder.Services.AddControllers(options =>
    {
       options.InputFormatters.Add(new TextMediaTypeFormatter()); 
    } );
builder.Services.AddControllers().AddXmlSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(configur =>
{
    //Create definitions
    configur.SwaggerDoc(Const.Level0Definition, new OpenApiInfo { Title = "REST Level 0", Version = "v1" });
    configur.SwaggerDoc(Const.Level1Definition, new OpenApiInfo { Title = "REST Level 1", Version = "v1" });
    configur.SwaggerDoc(Const.Level2Definition, new OpenApiInfo { Title = "REST Level 2", Version = "v1" });
    configur.SwaggerDoc(Const.Level3Definition, new OpenApiInfo { Title = "REST Level 3", Version = "v1" });
    configur.SwaggerDoc(Const.LevelMediatorDefinition, new OpenApiInfo { Title = "REST Mediator", Version = "v1" });

});

builder.Services.AddMediator(config =>
{
    config.RegisterServicesFromAssemblyContaining<PatientQuery>();
    config.AddBehavior<ValidationBehavior>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    // Use different definitions for route
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint($"/swagger/{Const.Level0Definition}/swagger.json", Const.Level0Definition); 
        c.SwaggerEndpoint($"/swagger/{Const.Level1Definition}/swagger.json", Const.Level1Definition); 
        c.SwaggerEndpoint($"/swagger/{Const.Level2Definition}/swagger.json", Const.Level2Definition); 
        c.SwaggerEndpoint($"/swagger/{Const.Level3Definition}/swagger.json", Const.Level3Definition); 
        c.SwaggerEndpoint($"/swagger/{Const.LevelMediatorDefinition}/swagger.json", Const.LevelMediatorDefinition);

    });
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
// app.UseEndpoints(endpoint =>
// {
//      endpoint.MapControllers();
// });

app.Run();