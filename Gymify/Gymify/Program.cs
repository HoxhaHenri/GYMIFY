using DI;
using Entities.Models;
using Lamar.Microsoft.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Gymify
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connString = builder.Configuration.GetConnectionString("Gymify");
            builder.Services.AddDbContext<GymifyContext>(options => options.UseSqlServer(connString));
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Host.UseLamar((context, registry) =>
            {
                // register services using Lamar
                registry.IncludeRegistry<GymifyRegistry>();
                // add the controllers
            });

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
}