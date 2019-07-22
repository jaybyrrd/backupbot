using BackupBot.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Discord.Bots
{
    class Program
    {
        public static void Main()
        {
            ServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddDbContext<BackupBot.Services.EntityFramework.GcContext>();
            Client client = new Client(serviceDescriptors);

            client.RunAsync().GetAwaiter().GetResult();
        }

    }
}
