using APBD_KOL2.Data;
using APBD_KOL2.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<IDbService, DbService>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();