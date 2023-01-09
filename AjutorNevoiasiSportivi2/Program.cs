using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using AjutorNevoiasiSportivi2.Configurations;
using AjutorNevoiasiSportivi2.Services;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var SpecificOrigins = "_allowSpecificOrigins";
builder.Services.AddCors(options =>
{
/*    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
            .WithHeaders(HeaderNames.ContentType);
        });*/
    options.AddPolicy(name: SpecificOrigins,
                       builder =>
                       {
                           builder.WithOrigins("http://localhost:4200")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                       });
});

// Add services to the container.
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
//
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c=>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "AjutorNevoiasiSportivi2", Version= "v1" });///////////////////
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n
                        Enter 'Bearer' [space] and then your token in the text input below.
                        \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name="Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
});


//Database connection
//builder.Services.AddDbContext<AjutorNevoiasiSportivi2Context>(options => options.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectSoftbinator;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AjutorNevoiasiSportivi2Context>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<AjutorNevoiasiSportivi2Context>();
//!!!!!!!!!!!!!!!!!!!!!!!!!!
builder.Services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer("AuthScheme", options =>
                {
                    options.SaveToken = true;
                    var secret = builder.Configuration.GetSection("Jwt").GetSection("SecretKey").Get<String>();//luam cheia secreta
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        RequireExpirationTime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    };
                });


builder.Services.AddAuthorization(opt =>
{
    opt.AddPolicy("NevoiasUser", policy => policy.RequireRole("NevoiasUser")
     .RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
    opt.AddPolicy("AdministratorClubUser", policy => policy.RequireRole("AdministratorClubUser")
     .RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
    opt.AddPolicy("DonatorUser", policy => policy.RequireRole("DonatorUser")
     .RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());

    opt.AddPolicy("DonatorUserOrAdmin", policy => policy
    .RequireRole("DonatorsUser", "AdministratorClubUser")
     .RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());

    opt.AddPolicy("NevoiasUserOrAdmin", policy => policy
    .RequireRole("NevoiasUser", "AdministratorClubUser")
     .RequireAuthenticatedUser().AddAuthenticationSchemes("AuthScheme").Build());
});

builder.Services.AddControllersWithViews()
        .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
//!!!!!!!!!!!!!!!!!!!!!!!!!
builder.Services.AddTransient<IEmailService, EmailService>();

builder.Services.AddTransient<ICompetitiiManager, CompetitiiManager>();
builder.Services.AddTransient<ICompetitiiRepository, CompetitiiRepository>();

builder.Services.AddTransient<IIstoricParticipariManager, IstoricParticipariManager>();
builder.Services.AddTransient<IIstoricParticipariRepository, IstoricParticipariRepository>();

builder.Services.AddTransient<IProbaManager, ProbaManager>();
builder.Services.AddTransient<IProbaRepository, ProbaRepository>();

builder.Services.AddTransient<IAdreseManager, AdreseManager>();
builder.Services.AddTransient<IAdreseRepository, AdreseRepository>();

builder.Services.AddTransient<ITalentatNevoiasiManager, TalentatNevoiasiManager>();
builder.Services.AddTransient<ITalentatNevoiasiRepository, TalentatNevoiasiRepository>();

builder.Services.AddTransient<IDonatoriManager, DonatoriManager>();
builder.Services.AddTransient<IDonatoriRepository, DonatoriRepository>();

builder.Services.AddTransient<ICluburiManager, CluburiManager>();
builder.Services.AddTransient<ICluburiRepository, CluburiRepository>();

builder.Services.AddTransient<ISporturiManager, SporturiManager>();
builder.Services.AddTransient<ISporturiRepository, SporturiRepository>();

builder.Services.AddTransient<IAntrenoriManager, AntrenoriManager>();
builder.Services.AddTransient<IAntrenoriRepository, AntrenoriRepository>();

builder.Services.AddTransient<IDonariManager, DonariManager>();
builder.Services.AddTransient<IDonariRepository, DonariRepository>();

builder.Services.AddTransient<IInscriereManager, InscriereManager>();
builder.Services.AddTransient<IInscriereRepository, InscriereRepository>();

builder.Services.AddTransient<IAuthenticationManager, AuthenticationManager>();
builder.Services.AddTransient<ITokenManager, TokenManager>();



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(SpecificOrigins);////////!!!!!!!!!!!!!!

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddleware>();
app.UseAuthorization();

app.MapControllers();

app.Run();
