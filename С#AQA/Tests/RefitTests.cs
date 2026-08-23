using Microsoft.Extensions.DependencyInjection;
using System.Net;
using C_AQA.Interfaces;
using Refit;
using C_AQA.DTO.FirstTestDTO;

namespace C_AQA.Tests
{
    public class RefitTests
    {
        private IUserApi api;

        [OneTimeSetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            services.AddRefitClient<IUserApi>()
            .ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://reqres.in/api");
            });

            var provider = services.BuildServiceProvider();

            api = provider.GetRequiredService<IUserApi>();
        }

        [Test]
        public async Task Test1()
        {
            var result = await api.GetUserAsync(2);
            Assert.That(result.Data.ID, Is.EqualTo(2));
        }

        [Test]
        public async Task Test2()
        {
            var request = new CreateUserRequestDTO { Name = "John", Job = "Apple" };
            var response = await api.CreateUserAsync(request);
            Assert.That(response.Name, Is.EqualTo("John"));
            Assert.That(response.Job, Is.EqualTo("Apple"));
        }

        [Test]
        public async Task Test3()
        {
            var deleteResult = await api.DeleteUserAsync(2);
            Assert.That(deleteResult.StatusCode, Is.EqualTo(HttpStatusCode.NoContent));
            //Assert.That((int)deleteResult.StatusCode, Is.EqualTo(204));
        }
    }
}
