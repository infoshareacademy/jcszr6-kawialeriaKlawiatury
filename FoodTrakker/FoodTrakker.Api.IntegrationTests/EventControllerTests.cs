

using FoodTrakker.Core.Model;

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


        [Fact]
        public async Task Get_ForEmptyEventList_ReturnOk()
        {
            //arrange

            _eventRepository
                .Setup(e => e.GetAsync())
                .Returns(Task.FromResult(FakeDbEvents.EmptyEventList));
            //act
            var response = await _client.GetAsync("/api/Event");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetEventById_ForValidRequest_ReturnOk()
        {
            //arrange

            _eventRepository
                .Setup(e => e.GetAsync(It.IsAny<int>()))
                .Returns(Task.FromResult(FakeDbEvents.Events[0]));
            //act
            var response = await _client.GetAsync("/api/Event/1");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetEventById_ForInvalidRequest_ReturnNotFound()
        {
            //arrange

            _eventRepository
                .Setup(e => e.GetAsync(It.IsAny<int>()))
                .Returns(Task.FromResult<Event>(null));
            //act
            var response = await _client.GetAsync("/api/Event/0");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.NotFound);
        }


    }
}