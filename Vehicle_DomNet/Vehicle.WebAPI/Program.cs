using Microsoft.EntityFrameworkCore;
using Vehicle.DAL;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository;
using Vehicle.Repository.Common;
using Vehicle.Service;
using Vehicle.Service.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddTransient<IVehicleMakeRepository, VehicleMakeRepository>();
builder.Services.AddTransient<IVehicleMakeModel, VehicleMakeModel>();

builder.Services.AddTransient<IVehicleModelService, VehicleModelService>();
builder.Services.AddTransient<IVehicleModelRepository, VehicleModelRepository>();
builder.Services.AddTransient<IVehicleModelModel, VehicleModelModel>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<VehicleContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<VehicleContext>();
    dataContext.Database.Migrate();
}

app.Run();
