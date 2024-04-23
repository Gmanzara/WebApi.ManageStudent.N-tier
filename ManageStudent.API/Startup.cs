using ManageStudent.Core;
using ManageStudent.Data;
using ManageStudent.Data.MongoDB.Setting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStudent.API
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
            //Configuration SQLserver*
            services.AddDbContext<ManageStudentDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //Pour chaque requete on lui associe une instance de UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Configuration MongoDb
            services.Configure<Settings>(
            options =>
            {
                options.ConnectionString = Configuration.GetValue<string>("MongoDB:ConnectionString");
                options.Database = Configuration.GetValue<string>("MongoDB:Database");
            });
            services.AddSingleton<IMongoClient,MongoClient>(
            _=> new MongoClient(Configuration.GetValue<string>("MongoDB:ConnectionString")));
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
