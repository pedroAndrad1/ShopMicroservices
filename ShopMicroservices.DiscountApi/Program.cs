using ShopMicroservices.BasketApi.CrossCutting;
using ShopMicroservices.DiscountApi.CrossCutting;
using ShopMicroservices.ProductApi.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
var serviceSettings = builder.Services.Bootstrap(builder.Configuration);
builder.Services.AddConsulSettings(serviceSettings, builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction()) app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
