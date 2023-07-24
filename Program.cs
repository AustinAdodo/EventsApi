using EventsApi.Repositories;
using EventsApi.Services;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        //builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
   //options.UseSqlServer(builder.Configuration.GetConnectionString("ProductsDBConnection")));
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