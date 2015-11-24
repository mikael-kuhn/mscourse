using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public static class Logger
    {
        public static List<string> Items  = new List<string>();

        public static void Log(string message)
        {
            Items.Add(message);
            Console.WriteLine(message);
        }
    }
}
