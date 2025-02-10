using Asp.Versioning.ApiExplorer;
using Microsoft.OpenApi.Models;
using ShopMicroservices.ProductApi.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductApi", Version = "v1" });
});
builder.Services.AddInfrastructure(builder.Configuration);
var serviceSettings = builder.Services.Bootstrap(builder.Configuration);
builder.Services.AddConsulSettings(serviceSettings, builder.Configuration);
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(8080); // Endpoint HTTP
    options.ListenAnyIP(8081, listenOptions =>
    {
        listenOptions.UseHttps(); // Endpoint HTTPS
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}
if(app.Environment.IsProduction()) app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
