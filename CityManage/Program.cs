using CityManage;
using Microsoft.AspNetCore;

public class Program
{
    public static void Main(string[] args) {
        CreateWebHostBuilder(args).Run();
    }

    public static IWebHost CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
}