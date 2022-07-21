using API.Data;
using API.Data.Repository;
using API.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AnalyzeDbSettings>(builder.Configuration.GetSection("ResultAnalyzeDatabase"));

builder.Services.AddSingleton<AnalyzeRepository>();
builder.Services.AddScoped<IAnalyzeRepository, AnalyzeRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
