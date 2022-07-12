using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BP.Ecommerce.Application;
using BP.Ecommerce.Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
// Cors config
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_myAllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//1. Configurar el esquema de Autentificacion JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"]
    };
});

//3. Configuration

builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JWT"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("_myAllowSpecificOrigins");

app.UseHttpsRedirection();
//2. registra el middleware que usa los esquemas de autenticacion registrados
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
