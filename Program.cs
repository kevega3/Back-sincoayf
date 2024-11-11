using Back_sincoayf.Services;
using Back_sincoayf.VehiculoBDContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin() // Permite cualquier origen
                   .AllowAnyMethod() // Permite cualquier método HTTP
                   .AllowAnyHeader(); // Permite cualquier encabezado
        });
});

builder.Services.AddScoped<ServicesVehiculo>();

builder.Services.AddDbContext<VehiculosDbContext>(options =>
    options.UseSqlServer(
        "Server=DESKTOP-3BLNNFO;Database=SincoAYF;User Id=tom;Password=Pescado12345*;TrustServerCertificate=True;",
       sqlOptions => sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 5,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null // Puedes agregar códigos de error específicos aquí si es necesario
        )));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
