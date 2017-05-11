using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupAssignmentpart1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initial commit
            Menu();

        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("");
            switch (Console.ReadKey().KeyChar)
            {
                case '1': Console.Clear(); Console.WriteLine("Q) Exit"); switch (Console.ReadKey().KeyChar) { case 'q': ConfirmToMenu(); break; } break;
                case 'q': ConfirmExit(); break;
            }
        }

        static void ConfirmExit()
        {
            Console.WriteLine("Are you sure you want to return to menu?");
            switch (Console.ReadKey().KeyChar)
            {
                case 'y': break;
                case 'n': Menu(); break;
            }
        }
            
        
    }
}
