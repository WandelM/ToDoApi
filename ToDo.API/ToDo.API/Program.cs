using Microsoft.EntityFrameworkCore;
using ToDo.API.DataAccess;
using ToDo.API.DbContexts;
using ToDo.API.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Host.ConfigureAppConfiguration((context, config) =>
{
    config.Sources.Clear();

    config.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ToDoItemProfile));
builder.Services.AddDbContext<ToDoApiContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddScoped(typeof(IToDoItemsRepository), typeof(ToDoItemsRepository));
builder.Services.AddScoped(typeof(IUsersRepository), typeof(UsersRepository));
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
