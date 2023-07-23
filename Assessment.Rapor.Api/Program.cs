using Assessment.Rapor.Api.Consumers;
using Assessment.Rapor.Api.Models;
using Assessment.Rapor.Api.Repositories.Concrete;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<RaporCevabiEventConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration.GetConnectionString("RabbitMQ"));

        cfg.ReceiveEndpoint("rapor-istegi-cevabi", e =>
        {
            e.ConfigureConsumer<RaporCevabiEventConsumer>(context);
        });

    });
});


var connectionString = builder.Configuration.GetConnectionString("PgConnectionString");

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connectionString), ServiceLifetime.Transient);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<RaporRepository, RaporRepository>();
builder.Services.AddScoped<RaporIcerikRepository, RaporIcerikRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

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
