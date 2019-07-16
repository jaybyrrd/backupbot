using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BackupBot.Domain
{
    class Program
    {
        public static readonly Client Client = new Client();
        static async Task Main(string[] args) => await Client.RunAsync();
    }
}
