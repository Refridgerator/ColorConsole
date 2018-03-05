using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ColorConsole
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Color Console";

            Print("<back:darkgray><blue>Hello<black>, <yellow>Habrahabr<black>!");
            Print();

            Print("<green>your secret code: <+>");
            for (int i = 0; i < 10; i++)
            {
                Print((i % 2 == 0 ? "<gray>" : "<white>") + i.ToString() + "<+>");
            }
            Print();
            Print();

            string filename = @"c:\MSDOS";
            File.WriteAllText(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"),
                Print("<red>ERROR: <gray>file <white>{0} <gray>not found", filename),
                Encoding.Default);
            Print();

            Print("<magenta>press any key to exit...");
            Console.ReadLine();
        }
    }
}
