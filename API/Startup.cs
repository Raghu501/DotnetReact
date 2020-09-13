using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Persistence;
using Microsoft.EntityFrameworkCore;
namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //notes: Dep injection container

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //var sp=services.BuildServiceProvider();

            services.AddDbContext<DataContext>(opt=>
            {                
                opt.UseSqlite(Configuration.GetConnectionString("defConnection"));
            });
            
        //     services.AddCors(opt=>
        //     opt.AddPolicy("corspolicy", builder => {
        //         builder.AllowAnyHeader()
        //         .AllowAnyMethod()
        //         .WithOrigins("http://localhost:3000");
        //     })
        //    );
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000");
                });
        });

           services.AddControllers();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else{

            }
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("corspolicy");
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //allow cors         

            //app.UseMvc();
        }
    }
}
