using System.Text.Json.Serialization;
using EgeBilgi_Infrastructure.Registiration;
using EgeBilgi_MediatR.Registiration;
using EgeBilgi_Persistence.Registiration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors(opt =>
    opt.AddDefaultPolicy(plc => plc.WithOrigins("http://localhost:3000"). AllowAnyHeader().AllowAnyMethod().AllowCredentials()));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEgeBilgiPersistenceRegistirations(builder.Configuration);
builder.Services.AddEgeBilgiInfrastructureRegistirations();
builder.Services.AddEgeBilgiMediatrRegistirations();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    });

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();