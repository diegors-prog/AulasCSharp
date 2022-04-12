using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CobrancaControle.Data.Context;
using CobrancaControle.Data.Repositories;
using CobrancaControle.Domain.Entities;
using CobrancaControle.Domain.Interfaces.RepositoryInterfaces;
using CobrancaControle.Domain.Interfaces.ServiceInterfaces;
using CobrancaControle.Services.Services;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CobrancaControle.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IChargeRepository, ChargeRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IChargeService, ChargeService>();
            services.AddScoped<IClientService, ClientService>();

            services.AddScoped<IValidator<Charge>, ChargeValidator>();
            services.AddScoped<IValidator<Client>, ClientValidator>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CobrancaControle.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CobrancaControle.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
