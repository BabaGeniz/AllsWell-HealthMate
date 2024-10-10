using AllsWellHealthMate.Data;
using AllsWellHealthMate.Repositories;
using AllsWellHealthMate.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure Entity Framework to use SQL Server with the connection string
builder.Services.AddDbContext<HealthMateDbContext>(options =>
{
   options.UseSqlServer("Server=DESKTOP-IEIE0FB\\SQLEXPRESS;Database=HealthMateDB;Trusted_Connection=True;TrustServerCertificate=True");
});



//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();
builder.Services.AddScoped<IHealthRecordRepository, HealthRecordRepository>();
builder.Services.AddScoped<IAllergyRepository, AllergyRepository>();
builder.Services.AddScoped<IPrescriptionRepository,PrescriptionRepository>();


// Register services
builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IHealthRecordService, HealthRecordService>();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthMate API", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthMate V1");
    c.RoutePrefix = string.Empty; // Set the Swagger UI at the app's root
});

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
