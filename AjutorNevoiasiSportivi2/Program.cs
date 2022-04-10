using AjutorNevoiasiSportivi2.Entities;
using AjutorNevoiasiSportivi2.Managers;
using AjutorNevoiasiSportivi2.Repositories;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Database connection
//builder.Services.AddDbContext<AjutorNevoiasiSportivi2Context>(options => options.UseSqlServer(@"Server=(localdb)\\MSSQLLocalDB;Initial Catalog=ProiectSoftbinator;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AjutorNevoiasiSportivi2Context>(
    options =>
    {
        options.UseSqlServer(connectionString);
    });


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

app.Run();
