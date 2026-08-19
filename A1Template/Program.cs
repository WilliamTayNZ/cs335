using Microsoft.EntityFrameworkCore;
using A1.Data;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();


        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SupportNonNullableReferenceTypes();
        });

        builder.Services.AddDbContext<A1DbContext>(options =>
            options.UseSqlite(builder.Configuration["P1DBConnection"]));

        // Tell the service container to use A1Repo as the implementation of IA1Repo if a program wants to use a IA1Repo type object
        builder.Services.AddScoped<IA1Repo, A1Repo>();

        var app = builder.Build();

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