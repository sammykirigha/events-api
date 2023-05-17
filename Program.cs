using System.Text;
using eventsApi.Configurations;
using eventsApi.Contracts;
using eventsApi.Entities;
using eventsApi.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<RepositoryContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqlOptions =>
{
    sqlOptions.EnableRetryOnFailure();
}));
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection(key:"JwtConfig"));
// builder.Services.AddAuthentication(configureOptions:options => 
// {
//   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
// .AddJwtBearer(jwt => 
// {
//     var key = Encoding.ASCII.GetBytes(builder.Configuration.GetSection(key: "JwtConfig: Secret").Value);

//     jwt.SaveToken = true;
//     jwt.TokenValidationParameters = new TokenValidationParameters()
//     {
//         ValidateIssuerSigningKey = true,
//         IssuerSigningKey = new SymmetricSecurityKey(key),
//         ValidateIssuer = false, // for dev
//         ValidateAudience = false, // for dev
//         RequireExpirationTime = false, //for dev
//         ValidateLifetime = true
//     };

// });
builder.Services.AddAutoMapper(typeof(Program).Assembly);
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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("Open");

app.Run();
