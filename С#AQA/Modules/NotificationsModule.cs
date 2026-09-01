using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.Interfaces.NotificationsInterfaces;
using C_AQA.Notifications;

namespace C_AQA.Modules
{
    public static class NotificationsModule
    {
        public static IServiceCollection AddNotifications(this IServiceCollection services)
        {
            services.AddScoped<IMessageSender, EmailSender>();
            services.AddScoped<UserNotifier>();
            return services;
        }
    }
}
