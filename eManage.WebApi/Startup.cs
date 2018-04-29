using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;

namespace eManage
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
            services.AddMvc();
            services.AddCors(options =>
            {

                options.AddPolicy("allowAll",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:8000");
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "eManage API",
                    Description = "Simple eManage API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Vincenzo Militello", Email = "vincenzo.militello@hotmail.com" }
                });
            });

            services.AddDbContext<eManage.Repo.eManageContext>(opt => opt.UseInMemoryDatabase("neverlandDb"));
            services.AddTransient<Domain.Interfaces.IUserRepo, eManage.Repo.UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            /*Log everyting*/
            loggerFactory.AddConsole();
            app.UseCors("allowAll");
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "eManage Api V1");
            });
        }
    }
}
