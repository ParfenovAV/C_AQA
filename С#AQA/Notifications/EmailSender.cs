using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.Interfaces.NotificationsInterfaces;

namespace C_AQA.Notifications
{
    public class EmailSender : IMessageSender
    {
        public void Send(string to, string text)
        {
            Console.WriteLine($"Sending mail to {to}: {text}");
        }
    }
}