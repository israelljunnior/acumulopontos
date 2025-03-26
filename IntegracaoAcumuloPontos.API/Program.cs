using FluentValidation.AspNetCore;
using FluentValidation;
using IntegracaoAcumuloPontos.Application.Validators;
using Ortobom.OSM.Repository.MapperConfig;
using IntegracaoAcumuloPontos.API.middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDependecies(builder.Configuration);
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddValidatorsFromAssemblyContaining<ConsumoDtoValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
