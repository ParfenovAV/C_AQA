using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using C_AQA.Interfaces.NotificationsInterfaces;
using C_AQA.Notifications;
using C_AQA.Preconditions;

namespace C_AQA.Tests
{
    internal class DependencyInjectionTests
    {
        private readonly NotificationsPreconditions p = new NotificationsPreconditions();

        [Test]
        public void Test001NotifierIsResolvedFromContainer()
        {
            // Просим готовый UserNotifier: контейнер сам создал EmailSender
            // и передал его в конструктор — мы нигде не писали new
            var notifier = p.Provider.GetService<UserNotifier>();

            notifier.Should().NotBeNull();
        }

        [Test]
        public void Test002SenderIsEmailSender()
        {
            // Проверяем, что по абстракции IMessageSender контейнер
            // отдаёт именно ту реализацию, которую мы зарегистрировали
            var sender = p.Provider.GetService<IMessageSender>();

            sender.Should().BeOfType<EmailSender>();
        }

        [Test]
        public void Test003NotifyWorks()
        {
            var notifier = p.Provider.GetService<UserNotifier>();

            // Метод отрабатывает без исключений и печатает сообщение в консоль
            Action act = () => notifier.Notify(42);

            act.Should().NotThrow();
        }
    }
}
