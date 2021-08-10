using System;

namespace BartenderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bartender = new Bartender(Console.ReadLine, Console.WriteLine);
            while(true)
            {
                bartender.AskForDrink();
            }
        }
    }
}
