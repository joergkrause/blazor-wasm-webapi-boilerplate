using Microsoft.EntityFrameworkCore;
using Workshop.Blazor.BusinessLogicLayer;
using Workshop.Blazor.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// DB
var connectionString = @"Data Source=(localdb)\BlazorWorkshop;Initial Catalog=EventDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
builder.Services.AddDbContext<EventDatabaseContext>(opt => opt.UseSqlServer(connectionString));

// Manager
builder.Services.AddScoped<IEventManager, EventManager>();
builder.Services.AddScoped<IFileUploadManager, FileUploadManager>();

// Mapper
builder.Services.AddAutoMapper(typeof(Manager).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
