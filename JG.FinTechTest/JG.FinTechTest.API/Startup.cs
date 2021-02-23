using JG.FinTechTest.API.Data;
using JG.FinTechTest.API.Repositories;
using JG.FinTechTest.API.Services;
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JG.FinTechTest.API
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
            services.AddControllers();
            services.AddTransient<IGiftAidCalculationService, GiftAidCalculationService>();
            services.AddDbContext<GiftAidDbContext>(options => options.UseInMemoryDatabase(databaseName: "GiftAidDb"));
            services.AddTransient<IGiftAidRepository, GiftAidRepository>();

            services.AddSwaggerGen(c=> {

                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Gift Aid Service",
                    Description = "Gift Aid Service",
                    TermsOfService = new Uri("https://github.com/PervaizAkhtar/Justgiving"),
                    Contact = new OpenApiContact
                    {
                        Name = "M Pervaiz Akhtar",
                        Email = "m.akhtar101@gmail.com",
                        Url = new Uri("https://github.com/PervaizAkhtar/Justgiving"),
                    }
                });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gift Aid Service");
            });

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
