using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.Interfaces.NotificationsInterfaces
{
    public interface IMessageSender
    {
        void Send(string to, string text);
    }
}