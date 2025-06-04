using GrupoBIOS.Application.Interface;
using GrupoBIOS.Application.Interface.Service;
using GrupoBIOS.Application.Main;
using GrupoBIOS.Application.Main.Service;
using GrupoBIOS.Domain.Core;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.InfraStructure.Data;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.InfraStructure.Repository;
using GrupoBIOS.Services.API.Helpers;
using GrupoBIOS.Transversal.Common;
using GrupoBIOS.Transversal.Logging;
using GrupoBIOS.Transversal.Mapper;
using Hangfire;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHangfire(config =>
{
    config.UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(builder.Configuration.GetConnectionString("BIOSConnection"));
});

builder.Services.AddHangfireServer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra HttpClient
builder.Services.AddHttpClient();

// 1. Primero carga la configuración
var appSettingsSection = builder.Configuration.GetSection("Config");
// 2. Luego configura los servicios
builder.Services.Configure<AppSettings>(appSettingsSection);

var appApiSiesaSection = builder.Configuration.GetSection("APISiesa");
builder.Services.Configure<ApiSiesa>(appApiSiesaSection);

builder.Services.AddTransient<SiesaAuthHandler>();
builder.Services.AddHttpClient("SiesaClient")
    .AddHttpMessageHandler<SiesaAuthHandler>();


//var appSettingsSection = builder.Configuration.GetSection("Config");
//builder.Services.Configure<AppSettings>(appSettingsSection);

// Configure JWT authentication
var appSettings = appSettingsSection.Get<AppSettings>();

var key = Encoding.ASCII.GetBytes(appSettings.Secret);
var IsSuer = appSettings.IsSuer;
var Audience = appSettings.Audience;

// Configuración JWT más completa
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true, // Cambia a true si quieres validar el issuer
        ValidIssuer = IsSuer,
        ValidateAudience = true, // Cambia a true si quieres validar el audience
        ValidAudience = Audience,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

builder.Services.AddControllers()

.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Mantener nombres exactos
    options.JsonSerializerOptions.DictionaryKeyPolicy = null;
});
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));


builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(
//      "CorsPolicy",
//      builder => builder.WithOrigins("http://bios.com", "https://bios.com", "http://localhost:5185/")
//      .AllowAnyMethod()
//      .AllowAnyHeader()
//      .AllowCredentials());
//});

builder.Services.AddSingleton<IConnectionFactory, ConnectionFactory>();

builder.Services.AddScoped<ITokenService, TokenService>();

// Registrar repositorios
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IUsuarioDomain, UsuarioDomain>();
builder.Services.AddScoped<IUsuarioApplication, UsuarioApplication>();
builder.Services.AddScoped<IClaseRepository, ClaseRepository>();
builder.Services.AddScoped<IClaseDomain, ClaseDomain>();
builder.Services.AddScoped<IClaseApplication, ClaseApplication>();
builder.Services.AddScoped<IParametroRepository, ParametroRepository>();
builder.Services.AddScoped<IParametroDomain, ParametroDomain>();
builder.Services.AddScoped<IParametroApplication, ParametroApplication>();
builder.Services.AddScoped<ICompaniaRepository, CompaniaRepository>();
builder.Services.AddScoped<ICompaniaDomain, CompaniaDomain>();
builder.Services.AddScoped<ICompaniaApplication, CompaniaApplication>();
builder.Services.AddScoped<IExcepcionRepository, ExcepcionRepository>();
builder.Services.AddScoped<IExcepcionDomain, ExcepcionDomain>();
builder.Services.AddScoped<IExcepcionApplication, ExcepcionApplication>();
builder.Services.AddScoped<IPncRepository, PncRepository>();
builder.Services.AddScoped<IPncDomain, PncDomain>();
builder.Services.AddScoped<IPncApplication, PncApplication>();

// Registrar UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Primero Authentication
app.UseAuthorization();  // Luego Authorization
app.UseCors("CorsPolicy");

app.UseHangfireDashboard();

app.MapControllers();

app.Run();
