using System.Threading.Tasks;
using BackupBot.Core;

namespace Discord.Bots
{
    class Program
    {
        public static readonly Client Client = new Client();
        static async Task Main(string[] args) => await Client.RunAsync();
    }
}
