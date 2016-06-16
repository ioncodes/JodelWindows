using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JodelAPI;

namespace JodelConsole
{
    class Program
    { 
        static List<Tuple<string, string>> jodels = new List<Tuple<string, string>>();
        static int jodelCounter = 0;
        static string delimiter = "===========================================";

        static void Main(string[] args)
        {
            Console.Title = "Jodel Viewer for Windows - Console Version";
            Console.OutputEncoding = Encoding.Unicode;
            API.accessToken = "9e98f945-e9b6-44a7-bcab-c831c190c35c";
            API.latitude = "47.48138427471329";
            API.longitude = "8.30048079354216";
            jodels = API.GetAllJodels();

            DisplayJodelsNext();

            InputToAction();
        }

        static void DisplayJodelsNext()
        {
            for (int i = 0; i < 10; i++)
            {
                if (jodelCounter < 149)
                {
                    Console.WriteLine(jodelCounter.ToString() + " =>");
                    Console.WriteLine(API.FilterItem(jodels, jodelCounter, true));
                    Console.WriteLine(delimiter);
                    jodelCounter++;
                }
                else
                {
                    Console.WriteLine("END OF JODELS");
                    break;
                }
            }
        }

        static void DisplayJodelsBack()
        {
            jodelCounter -= 10;
            for (int i = 0; i < 10; i++)
            {
                if (jodelCounter >= 0)
                {
                    jodelCounter--;
                    Console.WriteLine(jodelCounter.ToString() + " =>");
                    Console.WriteLine(API.FilterItem(jodels, jodelCounter, true));
                    Console.WriteLine(delimiter);
                }
                else
                {
                    Console.WriteLine("END OF JODELS");
                    break;
                }
            }
        }

        static void InputToAction()
        {
            again:
            string input = Console.ReadLine();

            if (input.Split(' ')[0] == "upvote")
            {
                API.Upvote(Convert.ToInt32(input.Split(' ')[1]));
            }
            else if(input.Split(' ')[0] == "downvote")
            {
                API.Downvote(Convert.ToInt32(input.Split(' ')[1]));
            }
            else if (input == "next")
            {
                DisplayJodelsNext();
            }
            else if(input == "back")
            {
                DisplayJodelsBack();
            }
            else if(input == "exit")
            {
                Console.WriteLine("Bye!");
                System.Threading.Thread.Sleep(500);
                Environment.Exit(0);
            }
            else if(input == "credits")
            {
                Console.WriteLine("Hi my name is ion. My GitHub: ioncodes");
            }
            else if(input == "help" || input == "?")
            {
                Console.WriteLine("Commands:");
                Console.WriteLine("help - This help message");
                Console.WriteLine("next - Show next 10 Jodels");
                Console.WriteLine("back - Show last 10 Jodels");
                Console.WriteLine("upvote [POSTNUMBER] - Upvotes the post");
                Console.WriteLine("downvote [POSTNUMBER] - Downvotes the post");
                Console.WriteLine("exit - Close this tool");
                Console.WriteLine("credits - Show credits of the developer");
            }
            goto again;
        }
    }
}
