using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;
using A1.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        builder.Services.AddDbContext<A1DbContext>(options =>
            options.UseSqlite(builder.Configuration["P1DBConnection"]));

        // Tell the service container to use A1Repo as the implementation of IA1Repo if a program wants to use a IA1Repo type object
        builder.Services.AddScoped<IA1Repo, A1Repo>();

        var app = builder.Build();
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();


    }

}