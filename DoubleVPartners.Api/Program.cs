using DoubleVPartners.Api.IoCRegister;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/* Inyectamos los CORS */
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder => builder
     .WithOrigins("http://localhost:4200")
     .AllowAnyMethod()
     .AllowAnyHeader()
     .AllowCredentials());
});

// Add services to the container.

builder.Services.AddControllers();

IoCRegister.AddRegistration(builder.Services, builder.Configuration.GetConnectionString("cnxBD"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api Double V Partners", Version = "v1" });
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Double V Partners v1");
    });
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
