using System.IO;
using System.Collections.Generic;
using System;

namespace AdventCommon
{
    public static class ConsoleHelpers
    {
        public static string[] ReadInput()
        {
            var lines = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines.ToArray();
        }
    }
}