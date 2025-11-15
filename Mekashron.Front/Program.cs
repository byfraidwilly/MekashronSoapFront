
using Mekashron.Front.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

builder.Services.AddScoped<ISoapService, SoapService>();
builder.Services.AddHttpClient<SoapService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseCors();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();

app.Run();



