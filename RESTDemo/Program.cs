using Microsoft.OpenApi.Models;
using RESTDemo;
using RESTDemo.Models;
using RESTDemo.Models.Internal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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