﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PRM_ProjectAPI.Repository;
using PRM_ProjectAPI.Models;

namespace PRM_ProjectAPI
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
            services.AddSwaggerGen(gen =>
            {
                gen.SwaggerDoc("v1.0", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "PRM391 API", Version = "v1.0" });
            });

            services.AddDbContext<PRM_JourneyToTheWestContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("PRM391_Final")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddJsonOptions(opt => opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); ;
            // mỗi lần có repository mới add thêm copy ra câu lên rồi đổi tên
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();       
            services.AddScoped<IToolRepository, ToolRepositoryRepo>();
            services.AddScoped<IScenarioRepository, ScenarioRepository>();
            services.AddScoped<IActorScenarioDetailRepository, ActorScenarioDetailRepository>();
            services.AddScoped<IToolScenarioDetailRepository, ToolScenarioDetailRepository>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(UI =>
            {
                UI.SwaggerEndpoint("/swagger/v1.0/swagger.json", "V1.1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
