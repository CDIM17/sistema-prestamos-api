using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using sistema_prestamos_api.Models;
using sistema_prestamos_api.Services;


namespace sistema_prestamos_api
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
            //Enable CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddSwaggerGen();

            //JSON serializer
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore).
            AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());

            services.AddControllers();

            services.AddTransient<AppDb>(_ => new AppDb(Configuration["ConnectionStrings:PrestamoAppCon"]));
            services.AddTransient<IPrestamoService, PrestamoService>();
            services.AddTransient<IEmpresaService, EmpresaService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //Enable CORS
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // app.UseSwagger();
            /*
             app.UseSwaggerUI(c =>
             {
                 c.SwaggerEndpoint("/swagger/v1/swagger.json", "NetCore3 API V1");
             });*/

            app.UseSwagger(o =>
            {
                o.RouteTemplate = "docs/{documentName}/docs.json";
            });
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            //This line enables Swagger UI, which provides us with a Nice, simple UI with which we can view our API calls.
            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "docs";
                c.InjectStylesheet("/swagger-ui/custom.css");
                c.InjectJavascript("../css/swagger-ui/custom.js");
                c.SwaggerEndpoint("../docs/v1/docs.json", "API v1");
                c.SwaggerEndpoint("../docs/v2/docs.json", "API V2");
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
