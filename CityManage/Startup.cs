using Microsoft.EntityFrameworkCore;
namespace CityManage;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; init;  }

    public virtual void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddDbContext<CityDbContext>(x =>
            x.UseMySQL(Configuration.GetConnectionString("DefaultConnectionString")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment()) {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();
        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }
}