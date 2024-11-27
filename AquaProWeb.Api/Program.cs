using AquaProWeb.Api.Exceptions;
using AquaProWeb.Application;
using AquaProWeb.Application.Mappings;
using AquaProWeb.Infrastructure;
using AquaProWeb.Infrastructure.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// gestio global d'excepcions

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();

// Add services to the container.

// CORS tot obert
//builder.Services.AddCors(policy => policy.AddPolicy("AquaProWeb.Api", options =>
//{
//    options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//}));

// CORS restringit
builder.Services.AddCors(policy => policy.AddPolicy("AquaProWeb.Api", options =>
{
    options.WithOrigins(builder.Configuration["BackEndUrl"] ?? "", builder.Configuration["FrontEndUrl"] ?? "")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials();
}));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

// registrem contextes i repos

builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddConfigurationDatabase(builder.Configuration);
builder.Services.AddAuthorizationDatabase(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddApplicationServices();
builder.Services.RegisterMappings();

var app = builder.Build();


app.UseCors("AquaProWeb.Api");

// fem el seeding

using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    try
    {
        var context = service.GetRequiredService<AppDbContext>();

        await context.Database.MigrateAsync();
        await AppDbContextSeedData.LoadDataAsync(context);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

// gestió d'excepcions
app.UseExceptionHandler(ops => { });

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();  // Enrutamiento de solicitudes

app.UseAuthentication();  // Autenticación de solicitudes

app.UseAuthorization();   // Autorización de solicitudes

app.MapControllers();  // Mapea los endpoints (MVC, Razor, API, etc.)

app.Run();

