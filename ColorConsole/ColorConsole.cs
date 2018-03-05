using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace ColorConsole
{
    public partial class Program
    {
        /// <summary>
        /// Multithreading synchronization 
        /// </summary>
        private static object _syncPrint = new object();

        /// <summary>
        /// Colorized text output
        /// </summary>        
        public static string Print(string text = "", params object[] values)
        {
            lock (_syncPrint)
            {
                Console.ResetColor();

                if (text.Length == 0)
                {
                    Console.WriteLine();
                    return "";
                }

                StringBuilder sb = new StringBuilder();
                StringWriter sw = new StringWriter();

                sw.Write(text, values);
                string s = sw.ToString();

                List<string> ss = new List<string>();

                int startpos = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '<')
                    {
                        ss.Add(s.Substring(startpos, i - startpos));
                        startpos = i;
                    }
                    if (s[i] == '>')
                    {
                        ss.Add(s.Substring(startpos, i - startpos + 1));
                        startpos = i + 1;
                    }
                }
                if (startpos < s.Length)
                {
                    string k = s.Substring(startpos, s.Length - startpos);
                    ss.Add(k);
                }


                foreach (string k in ss)
                {
                    string kk = k.ToLower();
                    switch (kk)
                    {
                        case "<black>": Console.ForegroundColor = ConsoleColor.Black; break;
                        case "<darkblue>": Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                        case "<darkred>": Console.ForegroundColor = ConsoleColor.DarkRed; break;
                        case "<darkmagenta>": Console.ForegroundColor = ConsoleColor.DarkMagenta; break;
                        case "<darkgreen>": Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                        case "<darkcyan>": Console.ForegroundColor = ConsoleColor.DarkCyan; break;
                        case "<darkyellow>": Console.ForegroundColor = ConsoleColor.DarkYellow; break;
                        case "<darkgray>": Console.ForegroundColor = ConsoleColor.DarkGray; break;
                        case "<darkgrey>": Console.ForegroundColor = ConsoleColor.DarkGray; break;
                        case "<blue>": Console.ForegroundColor = ConsoleColor.Blue; break;
                        case "<red>": Console.ForegroundColor = ConsoleColor.Red; break;
                        case "<magenta>": Console.ForegroundColor = ConsoleColor.Magenta; break;
                        case "<green>": Console.ForegroundColor = ConsoleColor.Green; break;
                        case "<cyan>": Console.ForegroundColor = ConsoleColor.Cyan; break;
                        case "<yellow>": Console.ForegroundColor = ConsoleColor.Yellow; break;
                        case "<gray>": Console.ForegroundColor = ConsoleColor.Gray; break;
                        case "<grey>": Console.ForegroundColor = ConsoleColor.Gray; break;
                        case "<white>": Console.ForegroundColor = ConsoleColor.White; break;

                        case "<back:black>": Console.BackgroundColor = ConsoleColor.Black; break;
                        case "<back:darkblue>": Console.BackgroundColor = ConsoleColor.DarkBlue; break;
                        case "<back:darkred>": Console.BackgroundColor = ConsoleColor.DarkRed; break;
                        case "<back:darkmagenta>": Console.BackgroundColor = ConsoleColor.DarkMagenta; break;
                        case "<back:darkgreen>": Console.BackgroundColor = ConsoleColor.DarkGreen; break;
                        case "<back:darkcyan>": Console.BackgroundColor = ConsoleColor.DarkCyan; break;
                        case "<back:darkyellow>": Console.BackgroundColor = ConsoleColor.DarkYellow; break;
                        case "<back:darkgray>": Console.BackgroundColor = ConsoleColor.DarkGray; break;
                        case "<back:darkgrey>": Console.BackgroundColor = ConsoleColor.DarkGray; break;
                        case "<back:blue>": Console.BackgroundColor = ConsoleColor.Blue; break;
                        case "<back:red>": Console.BackgroundColor = ConsoleColor.Red; break;
                        case "<back:magenta>": Console.BackgroundColor = ConsoleColor.Magenta; break;
                        case "<back:green>": Console.BackgroundColor = ConsoleColor.Green; break;
                        case "<back:cyan>": Console.BackgroundColor = ConsoleColor.Cyan; break;
                        case "<back:yellow>": Console.BackgroundColor = ConsoleColor.Yellow; break;
                        case "<back:gray>": Console.BackgroundColor = ConsoleColor.Gray; break;
                        case "<back:grey>": Console.BackgroundColor = ConsoleColor.Gray; break;
                        case "<back:white>": Console.BackgroundColor = ConsoleColor.White; break;
                        case "<+>": break;

                        default:
                            Console.Write(k);
                            sb.Append(k);
                            break;
                    }
                }
                if (!text.EndsWith("<+>")) Console.WriteLine();

                return sb.ToString();
            }
        }
    }
}
