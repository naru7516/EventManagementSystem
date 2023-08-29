using OnlineEventManagementSystem.Models;
using OnlineEventManagementSystem.Controllers;
using System;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace OnlineEventManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          //  builder.Services.AddDbContext<eventmanagementsystemdbContext>();
            builder.Services.AddDbContext<OnlineEventManagementSystem.Models.eventmanagementsystemdbContext>();
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            var app = builder.Build();
           
            app.UseCors(policy=>policy.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(origin=>true)
            .AllowCredentials());

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                        if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

                        
            app.Run();

           

        }
    }
}