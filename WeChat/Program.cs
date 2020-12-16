using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WeChat
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Common.Logging.Log4NetHelper.ConfigureAndWatch("Log4net.config");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostContext, logging) =>
            {
                //aspnetcore��log�������build����ӵģ����֮�������ܶ�������Ϣ��������build֮ǰ����Щ��Ϣ���˵�
                //logging.AddFilter("System", LogLevel.Warning);
                //logging.AddFilter("Microsoft", LogLevel.Warning);
                //logging.ClearProviders();
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory());
}
}
