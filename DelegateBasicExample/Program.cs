using System;

namespace DelegateBasicExample
{

    class Program
    {
        delegate void LogDel(string text, DateTime dateTime);

        static void Main(string[] args)
        {
            LogDel logdel = new LogDel(LogTextToScreen);

            Console.WriteLine("Please enter your name");

            var name = Console.ReadLine();

            while (name == null || name == "") {
                Console.WriteLine("Name cannot be empty. Please enter your name");
                name = Console.ReadLine(); 
            }

            logdel(name, DateTime.Now);

            Console.ReadKey();
        }

        static void LogTextToScreen(string text, DateTime dateTime)
        {
            Console.WriteLine($"{dateTime}: {text}");
        }
    }
}