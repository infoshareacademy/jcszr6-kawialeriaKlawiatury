using Microsoft.AspNetCore.Mvc;

namespace FoodTrakker.Api.IntegrationTests
{
    public class ProgramTests
    {
        private WebApplicationFactory<Program> _factory;
        private readonly List<Type> _controllerTypes;

        public ProgramTests()
        {
            _controllerTypes = typeof(Program)
                .Assembly
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(ControllerBase)))
                .ToList();

            _factory = new WebApplicationFactory<Program>()
            .WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    _controllerTypes.ForEach(c => services.AddScoped(c));
                });
            });
        }

        [Fact]
        public void ConfigureServices_ForControllers_RegistersAllDependencies()
        {
            var scopedFactory = _factory.Services.GetService<IServiceScopeFactory>();
            using var scope = scopedFactory.CreateScope();


            _controllerTypes.ForEach(t =>
            {
                var controller = scope.ServiceProvider.GetService(t);
                controller.Should().NotBeNull();
            });
        }


    }
}
