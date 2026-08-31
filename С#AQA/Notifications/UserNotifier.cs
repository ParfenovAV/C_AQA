using System;
using System.Collections.Generic;
using System.Text;
using C_AQA.Interfaces.NotificationsInterfaces;

namespace C_AQA.Notifications
{
    public class UserNotifier
    {
        private readonly IMessageSender sender;

        public UserNotifier(IMessageSender sender)
        {
            this.sender = sender;
        }

        public void Notify(int userId)
        {
            sender.Send("user@mail.com", $"Hello, user {userId}!");
        }
    }
}