using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Broidery.Api
{
    public class BaseProgram
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<BaseStartup>();
                });
    }
}
