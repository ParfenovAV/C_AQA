using C_AQA.DTO.BookStoreDTO;
using C_AQA.Interfaces.BookStore;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;

namespace C_AQA.Tests
{
    public class BookStoreTests
    {
        private IBookAPI api;

        [OneTimeSetUp]

        public void Setup()
        {
            var services = new ServiceCollection();

            services
                .AddRefitClient<IBookAPI>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri("https://demoqa.com");
                });

            var provider = services.BuildServiceProvider();
            api = provider.GetRequiredService<IBookAPI>();
        }

        //[Test] // тест проходит только один раз
        //public async Task TestCreateUser()
        //{
        //    var credentials = new UserCreateBodyDTO("TestAA", "StrongPass123!");
        //    var result = await api.CreateUserAsync(credentials); // "5dd4b7a9-40fc-4e5d-a00e-64c42ffde1c2" ID
        //    result.Username.Should().Be("MrPepe");
        //}

        [Test]
        public async Task TestGetToken()
        {
            var credentials = new UserCreateBodyDTO("TestAA", "StrongPass123!");
            var result = await api.GetUserTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }

    }
}