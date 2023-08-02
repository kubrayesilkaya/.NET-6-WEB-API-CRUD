using Microsoft.EntityFrameworkCore;
using User_Management_v2.Data;
using User_Management_v2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddTransient<UserService, UserService>();

builder.Services.AddDbContext<UsersDBContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("connectionString")
        )
    );

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
