using QFBNGH_ADT_2023241.Logic;
using QFBNGH_ADT_2023241.Models;
using QFBNGH_ADT_2023241.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;



namespace QFBNGH_ADT_2023241.Endpoint
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<VanDBContext>();

            services.AddTransient<IRepository<RentVan>, RentVanRepository>();
            services.AddTransient<IRepository<Van>, VanRepository>();
            services.AddTransient<IRepository<Brand>, BrandRepository>();

            services.AddTransient<IRentVanLogic, RentVanLogic>();
            services.AddTransient<IVanLogic, VanLogic>();
            services.AddTransient<IBrandLogic, BrandLogic>();


            services.AddCors();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "QFBNGH_ADT_2023241.Endpoint", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "QFBNGH_ADT_2023241.Endpoint v1"));
            }

            app.UseCors(x =>
                x.AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
                .WithOrigins("http://localhost:21071")
            //.WithOrigins("https://jsonplaceholder.typicode.com/)")
            );



            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
