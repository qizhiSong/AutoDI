using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDI.Entity;
using AutoDI.Extensions;
using AutoDI.IRepository;
using AutoDI.Other;
using AutoDI.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AutoDI
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

            services.AddScoped<DemoDbContext>();

            services.AddScopedRepository();
            //services.AddScoped<IDemoRepository<DemoEntity>>(x => new DemoRepository<DemoEntity>(x.GetRequiredService<DemoDbContext>()));

            //services.AddScoped(typeof(IDemoRepository<DemoEntity>), x => new DemoRepository<DemoEntity>(x.GetRequiredService<DemoDbContext>()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
