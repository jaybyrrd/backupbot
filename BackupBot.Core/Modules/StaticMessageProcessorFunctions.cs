using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace BackupBot.Core.Modules
{
    public static class StaticMessageProcessorFunctions
    {
        public static async Task DabProcessorAsync(SocketMessage arg)
        {
            if (arg.Content.ToLower().Contains("dab"))
            {
                int count = Regex.Matches(arg.Content.ToLower(), "dab").Count;
                await arg.Channel.SendMessageAsync(new string('x', count).Replace("x", ":dab:"));
            }
        }
    }
}
