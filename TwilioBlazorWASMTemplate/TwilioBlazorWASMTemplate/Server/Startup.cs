using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TwilioBlazorWASMTemplate.Shared;
using TwilioBlazorWASMTemplate.Server.Services;
using TwilioBlazorWASMTemplate.Server.Models;


namespace TwilioBlazorWASMTemplate.Server
{
    public class Startup
    {
        readonly string PermittedOrigins = "_permittedOrigins";
   
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // allows for cross origin request from the blazor front end
            services.AddCors(options =>
            {
                options.AddPolicy(name: PermittedOrigins,
                    builder =>
                    {
                        /// 
                        // TODO ---- Must replace with host address of main website!! 
                        ///
                        builder.WithOrigins("https://localhost:5001")
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                    });
            });
            //add twilio information to the config for easy of accesablity across application
            services.Configure<TwilioAccountDetails>(Configuration.GetSection("TwilioAccountDetails"));
            
            //added example service
            services.AddScoped<IExampleService, ExampleService>();
           
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();
            app.UseCors(PermittedOrigins);
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
