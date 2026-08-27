using Microsoft.AspNetCore.Authentication;
using AuthenticationEx2.Handler;
using AuthenticationEx2.Data;
using Microsoft.EntityFrameworkCore;
public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SupportNonNullableReferenceTypes();
        });
        builder.Services
            .AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, MyAuthHandler>("MyAuthentication", null)
            .AddScheme<AuthenticationSchemeOptions, AdminHandler>("AdminAuthentication", null);
        builder.Services.AddDbContext<AuthDbContext>(
            options => options.UseSqlite(builder.Configuration["AuthDbConnection"])
        );

        builder.Services.AddScoped<IAuthRepo, DbAuthRepo>();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireClaim("admin"));
            options.AddPolicy("UserOnly", policy => policy.RequireClaim("userName"));
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {

            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}