using eventsApi.Contracts;
using eventsApi.Entities;
using eventsApi.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaulConnection"), sqlServerOptionsAction: sqlOptions =>
{
    sqlOptions.EnableRetryOnFailure();
}));

builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddHttpsRedirection(options =>
// {
//     options.HttpsPort = 5000;
// });

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

app.UseCors("Open");

app.Run();
