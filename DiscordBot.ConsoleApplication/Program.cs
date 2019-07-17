using BackupBot;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Threading.Tasks;

namespace DiscordBot.ConsoleApplication
{
    class Program
    {

        public static void Main() => MainAsync().GetAwaiter().GetResult();

        static async Task MainAsync()
        {
            // load the token from the local text file.
            string token = null;
            ServiceCollection serviceDescriptors = new ServiceCollection();
            serviceDescriptors.AddLogging(builder => builder.AddConsole());

            using (FileStream fileStream = new FileStream("token.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader reader = new StreamReader(fileStream))
                {
                    token = await reader.ReadToEndAsync();
                }
            }

            Client client = new Client(token, serviceDescriptors);


            await client.RunAsync();
        }

    }
}
