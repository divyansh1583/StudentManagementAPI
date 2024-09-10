using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace StudentAdmission
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register Consul
            builder.Services.AddSingleton<IConsulClient, ConsulClient>(sp =>
            {
                var consulAddress = configuration["ConsulConfig:Address"];
                return new ConsulClient(cfg => cfg.Address = new Uri(consulAddress));
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

            // Consul registration
            var consulClient = app.Services.GetRequiredService<IConsulClient>();
            var uri = new Uri($"http://localhost:5002"); // Update with the actual URI of your service
            var registration = new AgentServiceRegistration()
            {
                ID = configuration["ConsulConfig:ServiceId"],
                Name = configuration["ConsulConfig:ServiceName"],
                Address = $"{uri.Host}",
                Port = uri.Port,
                Tags = new[] { "students", "admission", "api" }
            };

            app.Lifetime.ApplicationStarted.Register(() =>
            {
                consulClient.Agent.ServiceRegister(registration).Wait();
            });

            app.Lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            app.Run();
        }
    }
}
