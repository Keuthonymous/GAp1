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
            MainMenu();

        }

        static void MainMenu()
        {
            Menu menu = new Menu(new Dictionary<string, string> { { "1", "Something."},
                                                                  { "Q", "Exit."}},
                                 "Title");

            switch (menu.Show())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Q) Exit");
                    switch (Console.ReadKey().KeyChar)
                    {
                        case 'q':
                            ConfirmExit();
                            break;
                    } break;
                case "Q":
                case "q":
                    ConfirmExit();
                    break;
            }
        }

        static void ConfirmExit()
        {
            Console.WriteLine("Are you sure you want to return to menu?\n" +
                              "Y) Exit" +
                              "N) Stay");
            switch (Console.ReadKey().KeyChar)
            {
                case 'y': break;
                case 'n': MainMenu(); break;
            }
        }
            
        
    }
}
