using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;
using ReRoboRecords.BackEnd.Data;
using ReRoboRecords.BackEnd.Models;

var builder = WebApplication.CreateSlimBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

builder.Configuration.AddConfiguration(config);

var url = builder.Configuration["SupaBase:Url"];
var key = builder.Configuration["SupaBase:ApiKey"];



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<Supabase.Client>(
    provider => new Supabase.Client(
        url,
        key,
        new Supabase.SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
        }
    )
);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("http://localhost:5218")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();



