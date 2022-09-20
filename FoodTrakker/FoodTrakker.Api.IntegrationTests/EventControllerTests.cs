using FluentAssertions;
using FoodTrakker.Api.IntegrationTests.Mock;
using FoodTrakker.BusinessLogic.Models;
using FoodTrakker.Repository.Contracts;
using FoodTrakker.Repository.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FoodTrakker.Api.IntegrationTests
{
    public class EventControllerTests
    {
        private HttpClient _client;
        private WebApplicationFactory<Program> _factory;
        private Mock<IEventRepository> _eventRepository = new Mock<IEventRepository>();

        public EventControllerTests()
        {
            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        var dbContextServices = services.SingleOrDefault(service => service.ServiceType == typeof(DbContextOptions<FoodTrakkerContext>));
                        services.Remove(dbContextServices);

                        services.AddSingleton<IEventRepository>(_eventRepository.Object);

                        services
                            .AddDbContext<FoodTrakkerContext>(options => options.UseInMemoryDatabase("FoodTrakkerDb"));
                    });
                });
            _client = _factory.CreateClient();
        }

        [Fact]
        public async Task Get_ForProperRequest_ReturnOk()
        {
            //arrange

            _eventRepository
                .Setup(e => e.GetAsync())
                .Returns(Task.FromResult(FakeDbEvents.Events));
            //act
            var response = await _client.GetAsync("/api/Event");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }
    }
}