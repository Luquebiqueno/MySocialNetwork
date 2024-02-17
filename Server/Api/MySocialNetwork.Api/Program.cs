using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MySocialNetwork.Application.ServiceApplications;
using MySocialNetwork.Common.Application;
using MySocialNetwork.Common.Domain.Interfaces;
using MySocialNetwork.Common.Domain.Service;
using MySocialNetwork.Common.Domain.Token;
using MySocialNetwork.Common.Infrastructure.Repository;
using MySocialNetwork.Domain.Helpers;
using MySocialNetwork.Domain.Interfaces.Application;
using MySocialNetwork.Domain.Interfaces.Repository;
using MySocialNetwork.Domain.Interfaces.Service;
using MySocialNetwork.Domain.Services;
using MySocialNetwork.Repository.Context;
using MySocialNetwork.Repository.Dapper;
using MySocialNetwork.Repository.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<MySocialNetworkContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).EnableDetailedErrors());
builder.Services.AddScoped<IUnitOfWork<MySocialNetworkContext>, MySocialNetworkContext>();
builder.Services.AddScoped<IUsuarioLogado, UsuarioLogado>();
builder.Services.AddScoped<IUsuarioLogadoRepository, UsuarioLogadoRepository>();
builder.Services.AddTransient<ITokenService, TokenService>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<DbSession>();

//Repository
builder.Services.AddTransient(typeof(IRepositoryBase<,,>), typeof(RepositoryBase<,,>));
builder.Services.AddScoped(typeof(ISistemaMenuRepository<>), typeof(SistemaMenuRepository<>));
builder.Services.AddScoped(typeof(IUsuarioRepository<>), typeof(UsuarioRepository<>));
builder.Services.AddScoped(typeof(IPublicacaoRepository<>), typeof(PublicacaoRepository<>));

//Service
builder.Services.AddTransient(typeof(IServiceBase<,,>), typeof(ServiceBase<,,>));
builder.Services.AddScoped(typeof(ISistemaMenuService<>), typeof(SistemaMenuService<>));
builder.Services.AddScoped(typeof(IUsuarioService<>), typeof(UsuarioService<>));
builder.Services.AddScoped(typeof(IAutenticacaoService<>), typeof(AutenticacaoService<>));
builder.Services.AddScoped(typeof(IPublicacaoService<>), typeof(PublicacaoService<>));

//Application
builder.Services.AddTransient(typeof(IApplicationBase<,,>), typeof(ApplicationBase<,,>));
builder.Services.AddScoped(typeof(ISistemaMenuApplication<>), typeof(SistemaMenuApplication<>));
builder.Services.AddScoped(typeof(IUsuarioApplication<>), typeof(UsuarioApplication<>));
builder.Services.AddScoped(typeof(IAutenticacaoApplication<>), typeof(AutenticacaoApplication<>));
builder.Services.AddScoped(typeof(IPublicacaoApplication<>), typeof(PublicacaoApplication<>));

//Inicio Autenticação
var tokenConfiguration = new TokenConfiguration();
new ConfigureFromConfigurationOptions<TokenConfiguration>(builder.Configuration.GetSection("TokenConfiguration")).Configure(tokenConfiguration);
builder.Services.AddSingleton(tokenConfiguration);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = tokenConfiguration.Issuer,
        ValidAudience = tokenConfiguration.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.Secret))
    };
});

builder.Services.AddAuthorization(auth =>
{
    auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
});

//Fim Autenticação

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader());
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
