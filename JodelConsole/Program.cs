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
            Console.OutputEncoding = Encoding.Unicode;
            API.accessToken = "9e98f945-e9b6-44a7-bcab-c831c190c35c";
            API.latitude = "47.4813857209582";
            API.longitude = "8.300478143758946";
            jodels = API.GetAllJodels();

            DisplayJodelsNext();

            InputToAction();

            Console.Read();
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
            goto again;
        }
    }
}
