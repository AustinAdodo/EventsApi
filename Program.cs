using EventsApi.Repositories;
using Microsoft.EntityFrameworkCore;
using EventsApi.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        string? connctionString = builder.Configuration.GetConnectionString("EventsDBConnection");

        builder.Services.AddControllers();
        builder.Services.AddMemoryCache();
        builder.Services.AddDbContextPool<AppDbContext>(options =>
    options.UseMySql(connctionString,ServerVersion.AutoDetect(connctionString)));
        builder.Services.AddScoped<IEvents_Services, Events_Repository>();
        builder.Services.AddScoped<IParticipants_Services, Participants_Repository>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
    }
}