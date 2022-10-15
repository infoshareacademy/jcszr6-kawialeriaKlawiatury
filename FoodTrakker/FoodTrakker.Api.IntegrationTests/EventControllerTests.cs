using FoodTrakker.Core.Model;
using FoodTrakker.Services.DTOs;
using System.Text.Json;

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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetEventById_ForValidRequest_ReturnOk(int Id)
        {
            //arrange
            _eventRepository
                .Setup(e => e.GetAsync(Id))
                .Returns(Task.FromResult(FakeDbEvents.Events.Single(e => e.Id == Id)));
            //act
            var response = await _client.GetAsync($"/api/Event/{Id}");
            //var result = await response.Content.ReadFromJsonAsync<Event>();
            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async Task GetEventById_ForValidRequest_ReturnCorrectObject(int Id)
        {
            //arrange
            var testObject = FakeDbEvents.Events[Id - 1];

            _eventRepository
                .Setup(e => e.GetAsync(Id))
                .Returns(Task.FromResult(FakeDbEvents.Events.Single(e => e.Id == Id)));
            //act
            var response = await _client.GetAsync($"/api/Event/{Id}");
            var result = await response.Content.ReadFromJsonAsync<Event>();
            //assert
            result.Should().BeEquivalentTo(testObject);
        }

        [Fact]
        public async Task GetEventById_ForInvalidRequest_ReturnNotFound()
        {
            //arrange

            //act
            var response = await _client.GetAsync($"/api/Event/50");

            //assert
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.InternalServerError);
        }

        [Fact]
        public async Task Post_ForProperInput_InvokeAddAsyncMethodOnce()
        {
            //arrange
            EventDto @event = new EventDto
            {
                Id = 5,
                Name = "Dummy1",
                Description = "Test",
                Location = "testLocation",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
            };

            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            //act
            var response = await _client.PostAsJsonAsync("/api/Event", @event);

            //assert
            _eventRepository.Verify(e => e.AddAsync(It.Is<Event>(x => x.Id == @event.Id && x.Name == @event.Name)), Times.Once);
        }
    }
}