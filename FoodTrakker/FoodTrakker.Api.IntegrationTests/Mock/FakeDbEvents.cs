

using FoodTrakker.Core.Model;

namespace FoodTrakker.Api.IntegrationTests.Mock
{
    public static class FakeDbEvents
    {
        public static List<Event> Events = new List<Event>()
        {
            new Event()
            {
                Id = 1,
                Name = "Dummy",
            },
            new Event()
            {
                Id = 2,
                Name = "Dummy",
            },
            new Event()
            {
                Id = 3,
                Name = "Dummy",
            },
            new Event()
            {
                Id = 4,
                Name = "Dummy",
            }
        };
    }
}