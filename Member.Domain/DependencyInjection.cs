﻿using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Member.Domain
{
	public static class DependencyInjection
	{
        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}

