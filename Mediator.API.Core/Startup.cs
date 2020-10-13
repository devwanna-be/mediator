using System;
using System.IO;
using System.Reflection;
using FluentValidation.AspNetCore;
using Mediator.API.App.UseCase.Sample;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Mediator.API.Core
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                });
            });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(c => { c.JsonSerializerOptions.WriteIndented = true; })
                .AddFluentValidation(f => f.RegisterValidatorsFromAssemblyContaining<SampleValidation>());

            services.AddMediatR(typeof(SampleHandler).GetTypeInfo().Assembly);
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("sample", new OpenApiInfo
                {
                    Title = "Sample API Core with MediatR",
                    Version = $"SAMPLE-{Environment.Version.Major}.{Environment.Version.Minor}.{DateTime.Now:yyyyMMddHHmmss}",
                    Description = "Sample ASP.NET Core 3.1 REST API using MediatR"
                });

                string xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
                c.IncludeXmlComments(xmlDocPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseResponseBuffering();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/sample/swagger.json", "Mediator.API.Core");
                c.RoutePrefix = "swagger";
            });

            app.UseCors("AllowAnyOrigin");

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
