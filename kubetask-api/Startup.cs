using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kubetask_api.Data;
using kubetask_api.Data.Repositories;
using kubetask_api.Services;
using kubetask_api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace kubetask_api
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

            IConfigurationSection configSection = Configuration.GetSection("CosmosSettings");

            services.AddDbContext<KubeTaskContext>((options) => {
                options.UseCosmos(configSection["ServiceEndpoint"], configSection["Key"], configSection["DatabaseName"]);
            });
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<ITaskService, TaskService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, KubeTaskContext kubeTaskContext)
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

            // ensuer database is created with relevant collections
            kubeTaskContext.Database.EnsureCreatedAsync().GetAwaiter().GetResult();
        }
    }
}
