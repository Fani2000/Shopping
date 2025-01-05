using Shopping.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ProductContext>();

builder.Services.AddControllers(); // Register controllers
builder.Services.AddEndpointsApiExplorer(); // Add API endpoint explorer for Swagger
builder.Services.AddSwaggerGen(); // Add Swagger generator

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Generate Swagger JSON
    app.UseSwaggerUI(); // Serve Swagger UI
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // Map controllers to routes

app.Run();