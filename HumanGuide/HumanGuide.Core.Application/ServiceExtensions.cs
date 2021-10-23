using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace HumanGuide.Core.Application
{
    public static class ServiceExtensions
    {
        public static void AddMultiLingualSupport(this IServiceCollection services)
        {
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var cultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                     new CultureInfo("ru"),
                    new CultureInfo("ge")
                            };
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("ge");
                options.SupportedCultures = cultures;
                options.SupportedUICultures = cultures;
            });
        }

        public static void AddApplicatonLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
