using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using JodelAPI;

namespace JodelConsole
{
    class Program
    { 
        static List<Tuple<string, string, string, bool>> jodels = new List<Tuple<string, string, string, bool>>();
        static List<Tuple<string, string, string, int>> comments = new List<Tuple<string, string, string, int>>(); //only for 1 jodel
        static int jodelCounter = 0;
        static string delimiter = "===========================================";

        static void Main(string[] args)
        {
            Console.Title = "Jodel Viewer for Windows - Console Version";
            Console.OutputEncoding = Encoding.Unicode;
            API.accessToken = "d87efc34-22d2-4a2f-9a6c-ac086b10f308";
            API.latitude = "47.48138427471329";
            API.longitude = "8.30048079354216";
            API.countryCode = "CH";
            API.city = "Miami";

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
                    if(jodels[jodelCounter].Item4)
                    {
                        Console.WriteLine("THIS IS AN IMAGE!!");
                    }
                    else
                    {
                        Console.WriteLine(API.FilterItem(jodels, jodelCounter, true));
                    }
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
                    if (jodels[jodelCounter].Item4)
                    {
                        Console.WriteLine("THIS IS AN IMAGE!!");
                    }
                    else
                    {
                        Console.WriteLine(API.FilterItem(jodels, jodelCounter, true));
                    }
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
            else if (input.Split(' ')[0] == "downvote")
            {
                API.Downvote(Convert.ToInt32(input.Split(' ')[1]));
            }
            else if (input.Split(' ')[0] == "image")
            {
                Process.Start(API.FilterItem(jodels, Convert.ToInt32(input.Split(' ')[1]), true));
            }
            else if (input.Split(' ')[0] == "comments")
            {
                comments = API.GetComments(API.FilterItem(jodels, Convert.ToInt32(input.Split(' ')[1]), false));
                foreach(var c in comments)
                {
                    Console.WriteLine(delimiter);
                    Console.WriteLine("Text: "+ c.Item2);
                    Console.WriteLine("Votes: " + c.Item4);
                    Console.WriteLine(delimiter);
                }
            }
            else if (input.StartsWith("post"))
            {
                int index = input.IndexOf("post");
                string message = (index < 0)
                    ? input
                    : input.Remove(index, "post".Length);

                API.PostJodel(message);
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
                Console.WriteLine("image [POSTNUMBER] - Opens the image in browser");
                Console.WriteLine("post [TEXT] - Posts a new Jodel with the text");
                Console.WriteLine("comments [POSTNUMBER] - Shows the comments for the Jodel");
                Console.WriteLine("exit - Close this tool");
                Console.WriteLine("credits - Show credits of the developer");
            }
            goto again; // bad, i know; will be changed later
        }
    }
}
