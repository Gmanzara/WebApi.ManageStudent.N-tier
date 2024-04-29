using AutoMapper;
using ManageStudent.Core;
using ManageStudent.Core.Repositories;
using ManageStudent.Core.Services;
using ManageStudent.Data;
using ManageStudent.Data.MongoDB.Repositories;
using ManageStudent.Data.MongoDB.Setting;
using ManageStudent.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;

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
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //Configuration SQLserver*
            services.AddDbContext<ManageStudentDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Default")));
            //Pour chaque requete on lui associe une instance de UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Configuration MongoDb
            services.Configure<Settings>(
            options =>
            {
                options.ConnectionString = Configuration.GetValue<string>("MongoDB:Default");
                options.Database = Configuration.GetValue<string>("MongoDB:Database");
            });
            services.AddSingleton<IMongoClient,MongoClient>(
            _=> new MongoClient(Configuration.GetValue<string>("MongoDB:Default")));

            services.AddScoped<IComposerRepository,ComposerRepository>();
            services.AddTransient<IDatabaseSettings,DatabaseSettings>();

            services.AddTransient<IStudentService,StudentService>();
            services.AddTransient<ICourseService,CourseService>();
            services.AddTransient<IEnrollmentService,EnrollmentService>();
            services.AddTransient<IComposerService,ComposerService>();

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                { Title = "API Manage Student", Description = "DotNet Core Api 3 - with swagger" });
            });

            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/Swagger/v1/swagger.json", "Manage Student V1");
            });
        }
    }
}
