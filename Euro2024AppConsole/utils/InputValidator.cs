using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euro2024AppConsole.utils
{
    public static class InputValidator
    {
        public static int GetValidatedInput(string prompt)
        {
            int result;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    break;
                } 
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid number");
                }
            }
            return result;
        }
    }
}
