using API.Data;
using API.Data.Interfaces;
using NewsConsumerAPI.Data;
using NewsConsumerAPI.Data.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ClippingDbSettings>(builder.Configuration.GetSection("NewsConsumerDatabase"));

builder.Services.AddSingleton<ClippingRepository>();
builder.Services.AddScoped<ITwitterService, TwitterService>();
builder.Services.AddScoped<IClippingRepository, ClippingRepository>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
