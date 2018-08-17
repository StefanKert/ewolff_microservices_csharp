using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crimson.Backend.Models;
using Crimson.Backend.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Crimson.Backend
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddOptions<AppOptions>();
            services.Configure<AppOptions>(options =>
            {
                var urls = Configuration["urls"].Split(";");            
                options.ServerUrl = urls.FirstOrDefault(x => x.StartsWith("http://"));
            });

            services.AddTransient<AngebotRepository>();
            services.AddTransient<AntragRepository>();
            services.AddTransient<BerufRepository>();
            services.AddTransient<BriefkastenRepository>();
            services.AddTransient<HaushaltRepository>();
            services.AddTransient<KontakthistorieRepository>();
            services.AddTransient<PartnerRepository>();
            services.AddTransient<VertragRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
