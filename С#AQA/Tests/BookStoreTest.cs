using C_AQA.DTO.BookStoreDTO;
using C_AQA.Helpers;
using C_AQA.Interfaces.BookStore;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Refit;
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
            var credentials = new UserCreateRequestDTO("TestAA", "StrongPass123!");
            var result = await api.GenerateTokenAsync(credentials);
            result.Token.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetUserId()
        {
            var credentials = new UserCreateRequestDTO("TestAA", "StrongPass123!");
            var result = await api.GetUserIdAsync(credentials);
            result.UserId.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetBookListAsync()
        {
            var result = await api.GetBookListAsync();
            result.Should().NotBeNull();
            result.Books.Should().HaveCount(8);
            result.Books.Should().NotBeNullOrEmpty();
        }

        [Test]
        public async Task GetBookByIsbnAsync()
        {
            var result = await api.GetBookByIsbnAsync("9781449325862");
            result.Should().NotBeNull();
        }

        [Test]
        public async Task AddBookToUserAsync() // исправил DTO  тест зеленый
        {
            var token = await GetTokenAsync();

            var listOfBooks = await api.GetBookListAsync();
            var rndIsbn = RandomizerHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO //круглые скобки - потому что record, а не класс
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            var response = await api.AddBookToUserAsync(request, token);
            response.Should().NotBeNull();
        }

        [Test]
        public async Task DeleteBookByIsbn() // работает некорректно - приходит 400-я (должна 500-я), разобраться
        {
            var token = await GetTokenAsync();

            var userId = await GetUsersIdAsync();

            var request = new DeleteBookRequestDTO
            (
                "9781449331818",
                userId
            );

            var response = await api.DeleteBookFromUserAsync(request, token);
            response.Should().NotBeNull();
        }

        [Test]
        public async Task SendInvalidRequestAsync()
        {
            var listOfBooks = await api.GetBookListAsync();
            var rndIsbn = RandomizerHelper.GetRandomItem(listOfBooks.Books).Isbn;

            var userId = await GetUsersIdAsync();

            var request = new AddCollectionOfBooksToUserDTO
            (
                userId,
                new List<CollectionOfIsbnsDTO> { new CollectionOfIsbnsDTO(rndIsbn) }
            );

            Func<Task> act = async () => await api.AddBookToUserAsync(request, token: null);
            act.Should().ThrowAsync<ApiException>(); //.Where(p => p.StatusCode == System.Net.HttpStatusCode.BadRequest) - по статус кодам почему-то не отрабатывает
        }


        //вспомогательные методы
        private async Task<string> GetTokenAsync()
        {
            var credentials = new UserCreateRequestDTO("TestAA", "StrongPass123!");
            var token = await api.GenerateTokenAsync(credentials);
            var result = $"Bearer {token.Token}";
            return result;
        }

        private async Task<string> GetUsersIdAsync()
        {
            var credentials = new UserCreateRequestDTO("TestAA", "StrongPass123!");
            var result = await api.GetUserIdAsync(credentials);
            return result.UserId;
        }

    }
}