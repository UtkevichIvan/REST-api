using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Test.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Test;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<UsersContext>();
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app)
    {
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            app.UseSwagger(options =>
            {
                options.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers = new List<OpenApiServer>
                    {
                        new OpenApiServer
                        {
                            Url = "http://localhost:5283",
                            Description = "Dev server"
                        }
                    };
                });
            });
            app.UseSwaggerUI();
            app.UseDeveloperExceptionPage();
            
        }
        
        app.UseRouting();
      
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}