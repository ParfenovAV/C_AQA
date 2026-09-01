using C_AQA.DTO.DapperTestsDTO;
using C_AQA.Helpers;
using C_AQA.Interfaces;
using C_AQA.Interfaces.DapperTestsInterfaces;
using C_AQA.Preconditions;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;

namespace C_AQA.Tests
{
    internal class DapperTests
    {
        private readonly DataBasePreconditions p = new DataBasePreconditions();

        [Test]
        public async Task Test001CheckAllUsersCount()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUsersAsync();
            users.Should().HaveCount(15);
        }

        [Test]
        public async Task Test002GetUserById()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByIdAsync(15);
            users.Should().NotBeNull();
        }

        [Test]
        public async Task Test003GetUserByNameAndSurname()
        {
            var repo = p.Provider.GetService<IUserRepository>();
            var users = await repo.GetUserByNameAndSurname("Мария", "Павлова");
            users.Should().NotBeNull();
            users.firstName.Should().Be("Мария");
            users.lastName.Should().Be("Павлова");
        }

        [Test]
        public async Task Test004GetAddressByUserId()
        {
            var repo = p.Provider.GetService<IAddressRepository>();
            var address = await repo.GetAddressByUserId(1);
            address.Should().NotBeNull();
        }

        [Test]
        public async Task Test005CheckAllCategoryRepositoryCount()
        {
            var repo = p.Provider.GetService<ICategoryRepository>();
            var users = await repo.GetCategoriesAsync();
            users.Should().HaveCount(6);
        }

        [Test]
        public async Task Test006GetProductById()
        {
            var repo = p.Provider.GetRequiredService<IProductRepository>();
            var product = await repo.GetProductByIdAsync(1);

            product.Should().NotBeNull();
            product.Should().BeEquivalentTo(
                new ProductDTO(1, "iPhone 15", "Смартфон Apple", 79990, 15, 1));
        }

        [Test]
        public async Task Test007GetOrderItemsOfUserOrder()
        {
            var repo = p.Provider.GetRequiredService<IOrderRepository>();

            var order = await repo.GetOrderByIdAndUserIdAsync(1, 1);
            order.Should().NotBeNull();
            order!.status.Should().Be("Delivered");
            order.totalPrice.Should().Be(84980);

            var items = await repo.GetOrderItemsAsync(1);

            items.Should().BeEquivalentTo(new[]
            {
        new OrderItemDetailsDTO(1, "iPhone 15", 1, 79990),
        new OrderItemDetailsDTO(1, "Anker PowerBank", 1, 4990)
    });
        }

        //[Test] //генерация базы - раскомментить, а потом запустить тест разово
        //public async Task InitialiseTest()
        //{
        //    var connectionString = "Data Source=marketplace.db";
        //    await using var connection = new SqliteConnection(connectionString);
        //    await connection.OpenAsync();
        //    await DatabaseInitializer.InitializeAsync(connection);
        //}
    }
}
