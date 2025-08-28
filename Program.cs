using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Proy_back_QBD.Data;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Proy_back_QBD.Profiles;
using Proy_back_QBD.Services;
Env.Load(); // Cargar variables de entorno desde el archivo .env

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<TrabajadorMappingProfile>();  // Registra tu perfil explícitamente
    cfg.AddProfile<SedeMappingProfile>();  // Registra tu perfil explícitamente
    cfg.AddProfile<AsistenciaMappingProfile>();  // Registra tu perfil explícitamente
    cfg.AddProfile<PacienteMappingProfile>();  // Registra tu perfil explícitamente
    cfg.AddProfile<MedicoMappingProfile>();  // Registra tu perfil explícitamente
});

builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISedeService, SedeService>();
builder.Services.AddScoped<IAsistenciaService, AsistenciaService>();
builder.Services.AddScoped<IPacienteService,PacienteService>();
builder.Services.AddScoped<IMedicoService,MedicoService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar conexión a PostgreSQL
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection") ??
    $"Host={configuration["POSTGRES_HOST"]};" +
    $"Port={configuration["POSTGRES_PORT"]};" +
    $"Username={configuration["POSTGRES_USERNAME"]};" +
    $"Password={configuration["POSTGRES_PASSWORD"]};" +
    $"Database={configuration["POSTGRES_DB"]}";

Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseNpgsql(connectionString));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.AllowAnyOrigin() // Especifica orígenes permitidos en producción
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configurar el pipeline

    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
    });


app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");
app.UseRouting();
app.MapControllers();

app.Run();