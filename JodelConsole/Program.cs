using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using JodelAPI;
using JodelAPI.Objects;

namespace JodelConsole
{
    class Program
    {
        private static List<Jodels> _jodels;
        private static List<Comments> _comments;
        static int _jodelCounter = 0;
        static string delimiter = "===========================================";

        static void Main(string[] args)
        {
            Console.Title = "Jodel Viewer for Windows - Console Version - Updated for my first Star :)";
            Console.OutputEncoding = Encoding.Unicode;
            Account.AccessToken = "";
            Account.Latitude = "";
            Account.Longitude = "";
            Account.CountryCode = "";
            Account.City = "";

            _jodels = Jodel.GetAllJodels();

            DisplayJodelsNext();

            InputToAction();
        }

        static void DisplayJodelsNext()
        {
            for (int i = 0; i < 10; i++)
            {
                if (_jodelCounter < 149)
                {
                    Console.WriteLine(_jodelCounter + " =>");
                    Console.WriteLine(_jodels[_jodelCounter].IsImage
                        ? "THIS IS AN IMAGE!!"
                        : _jodels[_jodelCounter].Message);
                    Console.WriteLine(delimiter);
                    _jodelCounter++;
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
            _jodelCounter -= 10;
            for (int i = 0; i < 10; i++)
            {
                if (_jodelCounter >= 0)
                {
                    _jodelCounter--;
                    Console.WriteLine(_jodelCounter + " =>");
                    Console.WriteLine(_jodels[_jodelCounter].IsImage
                        ? "THIS IS AN IMAGE!!"
                        : _jodels[_jodelCounter].Message);
                    Console.WriteLine(delimiter);
                }
                else
                {
                    Console.WriteLine("END OF JODELS");
                    break;
                }
            }
        }

        private static void InputToAction()
        {
            again:
            string input = Console.ReadLine();

            if (input.Split(' ')[0] == "upvote")
            {
                Jodel.Upvote(_jodels[Convert.ToInt32(input.Split(' ')[1])].PostId);
            }
            else if (input.Split(' ')[0] == "downvote")
            {
                Jodel.Downvote(_jodels[Convert.ToInt32(input.Split(' ')[1])].PostId);
            }
            else if (input.Split(' ')[0] == "image")
            {
                Process.Start(_jodels[Convert.ToInt32(input.Split(' ')[1])].Message);
            }
            else if (input.Split(' ')[0] == "comments")
            {
                _comments = Jodel.GetComments(_jodels[Convert.ToInt32(input.Split(' ')[1])].PostId);
                foreach(var c in _comments)
                {
                    Console.WriteLine(delimiter);
                    Console.WriteLine("Text: "+ c.Message);
                    Console.WriteLine("Votes: " + c.VoteCount);
                    Console.WriteLine(delimiter);
                }
            }
            else if (input.StartsWith("post"))
            {
                int index = input.IndexOf("post", StringComparison.Ordinal);
                string message = (index < 0)
                    ? input
                    : input.Remove(index, "post".Length);

                Jodel.PostJodel(message);
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
