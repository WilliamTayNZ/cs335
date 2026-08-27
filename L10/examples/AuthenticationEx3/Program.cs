using Microsoft.AspNetCore.Authentication;
using AuthenticationEx3.Handler;
using AuthenticationEx3.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
            .AddScheme<AuthenticationSchemeOptions, AuthHandler>("Authentication", null);
        builder.Services.AddDbContext<AuthDbContext>(
            options => options.UseSqlite(builder.Configuration["AuthDbConnection"])
        );
        builder.Services.AddControllers();
        builder.Services.AddScoped<IAuthRepo, DbAuthRepo>();
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireClaim(ClaimTypes.Role, "admin"));
            options.AddPolicy("AuthOnly", policy =>
            {
                policy.RequireAssertion(context =>
                    context.User.HasClaim(c =>
                    (c.Value == "normalUser" || c.Value == "admin")));
            });
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
