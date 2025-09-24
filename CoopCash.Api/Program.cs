using System.Text;
using CoopCash.Api.Middlewares;
using CoopCash.App.Interfaces.Services;
using CoopCash.App.Services;
using CoopCash.Infra.Configurations;
using CoopCash.Infra.DependencyInjection;
using CoopCash.Infra.Security;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Config SMTP
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));


// Serviços
builder.Services.AddControllers();
builder.Services.AddSingleton<JwtService>();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var secret = builder.Configuration["Jwt:Secret"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret!))
        };
    });

builder.Services.AddAuthorization();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "CoopCash.Api v1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();

app.UseRouting();               // importante
app.UseCors("AllowFrontend");   // deve vir depois do UseRouting
app.UseAuthentication();        // obrigatório para JWT
app.UseAuthorization();

app.UseMiddleware<PermissionMiddleware>(); // antes do MapControllers() se necessário

app.MapControllers();

app.Run();
