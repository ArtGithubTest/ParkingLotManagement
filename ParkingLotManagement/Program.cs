using Microsoft.EntityFrameworkCore;
using ParkingLotManagement;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ParkingDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ParkingLotAPI", Version = "v1" });
});
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseCors();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(/*"/swagger/v1/swagger.json", "StudentApi V1"*/ "/swagger/v1/swagger.json", "ParkingLotAPI V1");
});
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();