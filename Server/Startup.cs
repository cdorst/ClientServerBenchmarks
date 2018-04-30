using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
            => services.AddMvcCore();

        public void Configure(IApplicationBuilder app)
            => app.UseMvc();
    }
}
