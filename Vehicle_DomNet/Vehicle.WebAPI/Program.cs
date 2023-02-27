using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Vehicle.DAL;
using Vehicle.Model;
using Vehicle.Model.Common;
using Vehicle.Repository;
using Vehicle.Repository.Common;
using Vehicle.Service;
using Vehicle.Service.Common;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
    policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    // Declare your services with proper lifetime

    builder.RegisterType<VehicleMakeService>().As<IVehicleMakeService>().InstancePerDependency();
    builder.RegisterType<VehicleMakeRepository>().As<IVehicleMakeRepository>().InstancePerDependency();
    builder.RegisterType<VehicleMakeModel>().As<IVehicleMakeModel>().InstancePerDependency();

    builder.RegisterType<VehicleModelService>().As<IVehicleModelService>().InstancePerDependency();
    builder.RegisterType<VehicleModelRepository>().As<IVehicleModelRepository>().InstancePerDependency();
    builder.RegisterType<VehicleModelModel>().As<IVehicleModelModel>().InstancePerDependency();

    builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerDependency();

});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
app.UseCors();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<VehicleContext>();
    dataContext.Database.Migrate();
}

app.Run();
