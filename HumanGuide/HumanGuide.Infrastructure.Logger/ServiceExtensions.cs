using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Sinks.MSSqlServer;
using System;

namespace HumanGuide.Infrastructure.Logger
{
    public static class ServiceExtensions
    {
        public static void AddLoggerLayer(this IServiceCollection services, IConfiguration configuration)
        {


            var logDB = configuration.GetConnectionString("DefaultConnection");


            var sinkOpts = new MSSqlServerSinkOptions
            {
                TableName = "LogEvents",
                SchemaName = "dbo",
                AutoCreateSqlTable = true,
                BatchPostingLimit = 1000,
                BatchPeriod = new TimeSpan(0, 0, 10)
            };



            Log.Logger = new LoggerConfiguration()
                    .ReadFrom.Configuration(configuration)
                    .WriteTo.MSSqlServer(
                        connectionString: logDB,
                        sinkOptions: sinkOpts)
                    .CreateLogger();
        }
    }
}
