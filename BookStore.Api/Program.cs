using BookStore.Api.Configuration;
using BookStore.Api.Data;
using BookStore.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("sqlve");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Policy access definition
//The application will allow requests from any domain to access its resources.
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", b => b.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Allowall");

app.UseAuthorization();

app.MapControllers();

AppDbInitializer.Seed(app);

app.Run();
