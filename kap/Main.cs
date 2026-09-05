using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace kap
{
    class MainClass
    {
        public static string[] lines;
        public static int LineIndex = 0;
        public static string line = string.Empty;
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();

        static public void Main(string[] args)
        {
            HelperMethods.GetfileLines(args);
            Log.AppendLog();
            // a loop to go every line and run the commands
            while (HelperMethods.IsOnEnd())
            {
                // get the current line
                line = lines[LineIndex];
                //gets the first word which is the caommnd for that line and runs a method for that command
                switch (HelperMethods.GetLineFirstWord(line))
                {
                    case "goto":
                        Commands.Goto();
                        break;
                    case "print":
                        Commands.Print();
                        break;
                    case "var":
                        Commands.Var();
                        break;
                    case "set":
                        Commands.Set();
                        break;
                    case "delay":
                        Commands.Delay();
                        break;
                    case "random":
                        Commands.Random();
                        break;
                    case "add":
                        Commands.Add();
                        break;
                    case "sub":
                        Commands.Sub();
                        break;
                    case "multi":
                        Commands.Multi();
                        break;
                    case "div":
                        Commands.Div();
                        break;
                    case "input":
                        Commands.Input();
                        break;
                    case "title":
                        Commands.Title();
                        break;
                    case "concat":
                        Commands.Concat();
                        break;
                    case "beep":
                        Commands.Beep();
                        break;
                    case "color":
                        Commands.Color();
                        break;
                    case "clear":
                        Commands.Clear();
                        break;
                    case "close":
                        Commands.Close();
                        break;
                    case "pause":
                        Commands.Pause();
                        break;
                    case "if":
                        Commands.If();
                        break;
                    //TODO: finish these commands
                    case "length":
                        Commands.Length();
                        break;
                    case "substring":
                        Commands.Substring();
                        break;
                    case "log":
                        Log.PrintLog();
                        break;
                    case "run":

                        break;
                    case "save":

                        break;
                    case "load":

                        break;
                }

                //goes to the next line
                LineIndex++;
            }
        }
    }
}