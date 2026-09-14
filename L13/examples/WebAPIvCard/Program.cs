using Microsoft.EntityFrameworkCore;
using WebAPIvCard.Data;
using WebAPIvCard.Helper;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<CardDbContext>(options =>
                            options.UseSqlite(builder.Configuration["vCardAPIConnection"]));
        builder.Services.AddScoped<ICardRepo, CardRepo>();
        builder.Services.AddMvc(options => options.OutputFormatters.Add(new VCardOutputFormatter()));

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
