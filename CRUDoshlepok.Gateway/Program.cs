using CRUDoshlepok.Core;
using CRUDoshlepok.Dal;
using CRUDoshlepok.Gateway.Configurations;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CRUDoshlepok.Gateway", Version = "v1" });
});

builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureDatabase(builder.Configuration);

builder.Services.ConfigureCore();

var app = builder.Build();

app.Services.ValidateMapperProfiles();

app.Services.MigrateDb();

app.UseSwagger();

app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CRUDoshlepok.Gateway v1"));

app.MapControllers();

app.Run();