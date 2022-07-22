using API.Data;
using API.Data.Repository;
using API.Data.Interfaces;
using API.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<AnalyzeDbSettings>(builder.Configuration.GetSection("ResultAnalyzeDatabase"));

builder.Services.AddSingleton<AnalyzeRepository>();
builder.Services.AddSingleton<NewsConsumerService>();
builder.Services.AddScoped<IAnalyzeRepository, AnalyzeRepository>();
builder.Services.AddScoped<INewsConsumerService, NewsConsumerService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
