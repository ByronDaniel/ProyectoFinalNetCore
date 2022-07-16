using Microsoft.EntityFrameworkCore;
using System.Reflection;
using BP.Ecommerce.Application;
using BP.Ecommerce.Infraestructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BP.Ecommerce.API.Utils;
using BP.Ecommerce.API.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddInfraestructure(builder.Configuration);
builder.Services.AddApplication(builder.Configuration);
// Add services to the container.
builder.Services.AddControllers(options =>
{
    //Aplicar filter globalmente a todos los controller
    options.Filters.Add<ApiExceptionFilterAttribute>();
})

;
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
        ValidateIssuer = false,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"]
    };
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Ecuatoriano", policy => policy.RequireClaim("Ecuatoriano", true.ToString()));
});

// Config 1 Cors config
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: "_myAllowSpecificOrigins", builder =>
//    {
//        builder.WithOrigins("http://localhost:4200")
//        .AllowAnyMethod()
//        .AllowAnyHeader();
//    });
//});

builder.Services.AddCors();


//3. Configuration
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("JWT"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Config 1 Cors config
//app.UseCors("_myAllowSpecificOrigins");
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // Permitir cualquier origen
    .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
