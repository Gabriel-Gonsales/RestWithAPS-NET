using Microsoft.EntityFrameworkCore;
using RestWithASP_NET.Model.Context;
using RestWithASP_NET.Services;
using RestWithASP_NET.Services.Implementations;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddScoped<IPersonService, PersonServiceImplementation>();

        string connection = Conexao(builder: builder);

        builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)));

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
}