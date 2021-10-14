using Hangfire;
using Newtonsoft.Json;

namespace Mediator.API.Core.Helper
{
    public static class HangfireExtension
    {
        public static void UseMediatR(this IGlobalConfiguration configuration)
        {
            var jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
            configuration.UseSerializerSettings(jsonSettings);
        }
    }
}
