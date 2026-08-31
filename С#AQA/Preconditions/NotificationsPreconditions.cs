using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.Modules;

namespace C_AQA.Preconditions
{
    public class NotificationsPreconditions
    {
        public ServiceProvider Provider { get; }

        public NotificationsPreconditions()
        {
            var services = new ServiceCollection();
            services.AddNotifications();          
            Provider = services.BuildServiceProvider();   
        }
    }
}
