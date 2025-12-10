using System;
using Telhai.Csharpproject._01Practice.Logger;

namespace Telhai.Csharpproject._01Practice.Logger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string osVersion = Environment.OSVersion.ToString();
            string userName = Environment.UserName;
            string machineName = Environment.MachineName;

            Console.WriteLine($"Current User   : {userName}");
            Console.WriteLine($"Machine Name   : {machineName}");
            Console.WriteLine($"OS Version     : {osVersion}");
            Console.WriteLine("-------------------");

            Console.WriteLine("Hello, World!");

            for (int i = 0; i < 10; i++)
            {
                if (i % 5 == 0)
                {
                    Logger.log($"Running Main {i}", LogLevel.Debug);
                    continue;
                }

                Logger.log($"Running Main {i}");
            }
        }
    }
}
