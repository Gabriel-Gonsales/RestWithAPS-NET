using Microsoft.EntityFrameworkCore;
using RestWithASP_NET.Model.Context;
using RestWithASP_NET.Repository;
using RestWithASP_NET.Repository.Implementations;
using RestWithASP_NET.Business;
using RestWithASP_NET.Business.Implementations;
using Serilog;
using EvolveDb;

internal class Program
{

    public static IWebHostEnvironment? Environment { get; }
    public static void Main(string[] args)
    {

        Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddApiVersioning();

        builder.Services.AddScoped<IPersonRepository,PersonRepositoryImplementation>();
        builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();

        string connection = Conexao(builder: builder);

        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

        if (Environment.IsDevelopment())
        {
            MigrateDatabase(connection);
        }

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseRouting();

        app.MapControllers();

        app.Run();

        static string Conexao(WebApplicationBuilder builder)
        {
            return builder.Configuration["MySQLConnection:MySQLConnectionString"];
        }
    }

    private static void MigrateDatabase(string connection)
    {
        try
        {
            var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
            var evolve = new Evolve.Evolve(evolveConnection, MsgBoxResult => Log.Information(msg))
            {
                Locations = new List<string> { "db/migrations", "db/dataset" },
                IsEraseDisabled = true,
            };
            evolve.Migrate();
        }
        catch (Exception ex)
        {
            Log.Error("Database migration failed", ex);
            throw;
        }
    }
}