using ASP.NET_Core_Exam.Extensions;
using ASP.NET_Core_Exam.Mappers;
using ASP.NET_Core_Exam.Services;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var assemblyName = Assembly.GetExecutingAssembly().GetName().Name
			?? throw new NullReferenceException("AssemblyName");

builder.Services.AddDbContext<DataContext>(
	options => {
		options.UseNpgsql(
			builder.Configuration.GetConnectionString("PostgreSQL"),
			sqliteOptions => sqliteOptions.MigrationsAssembly(assemblyName)
		);
	}
);

builder.Services.AddAutoMapper(typeof(AppMapProfile));

builder.Services.AddTransient<IContentSeeder, ContentSeeder>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(configuration => configuration.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("Content-Disposition"));

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment()) {
	await app.SeedTestContentAsync();
}

app.Run();
