using System;
using System.IO;

namespace DelegateBasicExample
{

    class Program
    {
        delegate void LogDel(string text);

        static void Main(string[] args)
        {

            Log log = new Log();

            // Crearing a multi call delegate
            LogDel LogTextToScreenDel, LogTextToFileDel;
            LogTextToScreenDel = new LogDel(log.LogTextToScreen);
            LogTextToFileDel = new LogDel(log.LogTextToFile);
            // plus operator is overloaded to combine the delegates
            LogDel multiLogDel = LogTextToFileDel + LogTextToScreenDel;

            Console.WriteLine("Please enter your name");

            var name = Console.ReadLine();

            while (name == null || name == "")
            {
                Console.WriteLine("Name cannot be empty. Please enter your name");
                name = Console.ReadLine();
            }

            // Passing delegate as argument to another function
            // Any LogDel object could be passed in to get different logging behavior
            LogText(multiLogDel, name);

            Console.ReadKey();
        }

        static void LogText(LogDel logDel, string text)
        {
            logDel(text);
        }
    }

    class Log
    {

        public void LogTextToScreen(string text)
        {
            Console.WriteLine($"{DateTime.Now}: {text}");
        }

        public void LogTextToFile(string text)
        {
            using (StreamWriter sw = new StreamWriter(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log.txt"), true))
            {
                sw.WriteLine($"{DateTime.Now}: {text}");
            }
        }
    }
}
