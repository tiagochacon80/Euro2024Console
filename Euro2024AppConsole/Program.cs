// See https://aka.ms/new-console-template for more information
using Euro2024AppConsole.Models;

namespace Euro2024AppConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamService teamService = new TeamService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Eurocup cup table 2024");
                Console.WriteLine();
            }
        }
    }
}
