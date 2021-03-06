﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomationModel;
using HomeAutomationRepository.Concrete;
using HomeAutomationRepository.Interface;
using HomeAutomationService.Concrete;
using HomeAutomationService.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace HomeAutomation
{
    public class Startup
    {
        //        public Startup(IConfiguration configuration)
        //        {
        //            Configuration = configuration;
        //        }

        //        public IConfiguration Configuration { get; }

        //        // This method gets called by the runtime. Use this method to add services to the container.
        //        public void ConfigureServices(IServiceCollection services)
        //        {
        //            services.AddSingleton(Configuration);
        //            services.AddDbContext<HomeAutomationContext>(options =>
        //                options.UseNpgsql(Configuration.GetConnectionString("HomeAutomationConnection")));
        //            //services.AddDbContext<HomeAutomationContext>(options => options.Use(Configuration["ConnectionStrings:DefaultConnection"]));
        //            //services.AddSingleton<IConfiguration>(Configuration);
        //            services.AddScoped<IHomeAssistantService, HomeAssistantService>();
        //            services.AddScoped<IHomeAssistantRepository, HomeAssistantRepository>();
        //            services.AddMvc();
        //        }

        //        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //        {
        //            if (env.IsDevelopment())
        //            {
        //                app.UseDeveloperExceptionPage();
        //            }

        //            app.UseMvc();
        //        }
        //    }
        //}


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<HomeAutomationContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("HomeAutomationConnection")));
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddScoped<IHomeAssistantService, HomeAssistantService>();
            services.AddScoped<IHomeAssistantRepository, HomeAssistantRepository>();
            services.AddMvc();
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //else
            //{
            //    app.UseHsts();
            //}
            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
