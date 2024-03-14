using ElasticsearchDemo;
using Microsoft.EntityFrameworkCore;
using Nest;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IElasticClient>(sp =>
{
    return new ElasticClient(new ConnectionSettings(new Uri("http://elastic:Zsq.123456@192.168.0.150:9200")));
});

builder.Services.AddDbContext<HotelContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("Hotel"),
        Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
