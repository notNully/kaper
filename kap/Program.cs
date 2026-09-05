

using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;
using static System.Net.Mime.MediaTypeNames;

namespace Kap
{
    class Program
    {
        public static string[] lines;
        public static int LineIndex = 0;
        public static string line = string.Empty;
        public static Dictionary<string, string> Variables = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            //to run a kap file there is two ways:
            //go to the folder that has the kap file and open cmd by right clicking and seclect 'open in terminal' then type 'kap file.kap'
            if (args.Length > 0)
            {
                string filePath = args[0];

                if (File.Exists(filePath))
                {
                    if (Path.GetExtension(filePath) == ".kap")
                    {
                        lines = File.ReadAllLines(filePath);
                    }
                    else
                    {
                        Console.WriteLine("file is not a .kap file");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                else
                {
                    Console.WriteLine("Error: File not found.");
                }
            }
            else
            {
                Console.WriteLine("No file provided");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.Clear();


            // a loop to go every line and run teh commands
            while (LineIndex < lines.Length)
            {
                // get the current line
                line = lines[LineIndex];

                switch (GetLineFirstWord(line))
                {
                    case "goto":
                        Goto();
                        break;
                    case "print":
                        Print();
                        break;
                    case "var":
                        Var();
                        break;
                    case "set":
                        Set();
                        break;
                    case "delay":
                        Delay();
                        break;
                    case "random":
                        Random();
                        break;
                    case "add":
                        Add();
                        break;
                    case "sub":
                        Sub();
                        break;
                    case "multi":
                        Multi();
                        break;
                    case "div":
                        Div();
                        break;
                    case "input":
                        Input();
                        break;
                    case "title":
                        Title();
                        break;
                    case "concat":
                        Concat();
                        break;
                    case "beep":
                        Beep();
                        break;
                    case "color":
                        Color();
                        break;
                    case "clear":
                        Clear();
                        break;
                    case "close":
                        Close();
                        break;
                    case "pause":
                        Pause();
                        break;
                    case "if":
                        If();
                        break;
                    case "run":

                        break;
                    case "save":

                        break;
                    case "load":

                        break;
                }
                LineIndex++;
            }
        }

        /// <summary>
        /// if this line start with X then return true
        /// </summary>
        /// <param name="word">add the word to search in the line</param>
        /// <param name="line">the line</param>
        /// <returns></returns>
        static public bool LineStartWith(string word, string line)
        {
            bool isTrue = false;
            if (line.StartsWith(word))
            {
                isTrue = true;
            }
            return isTrue;
        }

        /// <summary>
        /// to get the first word which is the command, this method for the switch
        /// </summary>
        /// <param name="line">the line to extract the command</param>
        /// <returns></returns>
        static public string GetLineFirstWord(string line)
        {
            string[] words = line.Split(' ');
            return words[0];
        }

        /// <summary>
        /// gets the words typed after the command, exsample: goto(command) 6(parameters)
        /// </summary>
        /// <param name="line">line to extract teh parameters</param>
        /// <returns></returns>
        static public string[] GetParamters(string line)
        {
            string[] Words = line.Split(' ');
            int SubstringCommand = 1 + Words[0].Length;
            string[] Parameters = line.Substring(SubstringCommand).Split(' ');
            return Parameters;
        }

        /// <summary>
        /// checks if the value is from the Variables list, exsample print T playerHealth(from the variables) now instead of printing "playerHealth" we get it value from the list so it prints "100"
        /// </summary>
        /// <param name="var">the name of the variable to check if it on the list to get it's value</param>
        static public string CheckIfVariable(string var)
        {
            if (Variables.ContainsKey(var))
            {
                var = Variables[var];
                
            }
            return var;
        }

        /// <summary>
        /// checks if it's a Variable from the variable list
        /// </summary>
        /// <param name="var">the name of teh variable</param>
        /// <returns></returns>
        static public bool IsVariable(string var)
        {
            bool ReturnBool = false;
            if (Variables.ContainsKey(var))
            {
                ReturnBool = true;
            }
            return ReturnBool;
        }




        //All Commands logic are down here:



        /// <summary>
        /// a Command to go to a line
        /// command: goto [line:number]
        /// </summary>
        static public void Goto()
        {
            string[] Parameters = GetParamters(line);
            int targetLine = int.Parse(Parameters[0]);
            LineIndex = targetLine - 1;
        }

        /// <summary>
        /// a command to print text on a screen
        /// command: print [T/F new line] [text]
        /// </summary>
        static public void Print()
        {
            string text = line.Substring(8);
            text = CheckIfVariable(text);
            if (line.Substring(6,1) == "F")
            {
                Console.Write(text);
            } 
            else if (line.Substring(6, 1) == "T")
            {
                Console.WriteLine(text);
            }
        }

        /// <summary>
        /// a commnad to create a variable
        /// command: var [variable name] [value] 
        /// note: if your are making a text type '-' to be a space
        /// </summary>
        static public void Var()
        {
            string[] Parameters = GetParamters(line);
            string Name = Parameters[0];
            string value = Parameters[1];
            if(IsVariable(Name))
            {
                Variables.Remove(Name);
                Variables.Add(Name, value.Replace("-", " "));
            }
            else
            {
                Variables.Add(Name, value.Replace("-", " "));
            }
        }

        /// <summary>
        /// a command to modify a variable value
        /// command: set [variable Name] [value]
        /// </summary>
        static public void Set()
        {
            string[] Parameters = GetParamters(line);
            string Name = Parameters[0];
            string value = Parameters[1];
            value = CheckIfVariable(value);
            if(IsVariable(Name))
            {
                Variables[Name] = value;
            }
        }

        /// <summary>
        /// a command to wait
        /// command: delay [miliseconds]
        /// </summary>
        static public void Delay()
        {
            string Paramter = line.Substring(6);
            System.Threading.Thread.Sleep(int.Parse(Paramter));
        }

        /// <summary>
        /// a command to make a random number
        /// command: random [min] [max] [variable]
        /// </summary>
        public static void Random()
        {
            string[] Parameters = GetParamters(line);
            string min = Parameters[0];
            string max = Parameters[1];
            string variable = Parameters[2];
            if (IsVariable(variable))
            {
                Random random = new Random();
                Variables[variable] = random.Next(int.Parse(min), int.Parse(max)).ToString();
            }
        }

        /// <summary>
        /// a commad to add numbers
        /// command: add [number1] [number2] [variable]
        /// </summary>
        public static void Add()
        {
            string[] Parameters = GetParamters(line);
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            number1 = CheckIfVariable(number1);
            number2 = CheckIfVariable(number2);
            int result = int.Parse(number1) + int.Parse(number2);
            if (IsVariable(variable))
            {
                Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a command to subtrac numbers
        /// command: sub [number1] [number2] [variable]
        /// </summary>
        public static void Sub()
        {
            string[] Parameters = GetParamters(line);
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            number1 = CheckIfVariable(number1);
            number2 = CheckIfVariable(number2);
            if (IsVariable(variable))
            {
                Variables[variable] = (int.Parse(number1) - int.Parse(number2)).ToString();
            }
        }

        /// <summary>
        /// a commad to multiply numbers
        /// command: multi [number1] [number2] [variable]
        /// </summary>
        public static void Multi()
        {
            string[] Parameters = GetParamters(line);
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            number1 = CheckIfVariable(number1);
            number2 = CheckIfVariable(number2);
            if (IsVariable(variable))
            {
                Variables[variable] = (int.Parse(number1) * int.Parse(number2)).ToString();
            }
        }

        /// <summary>
        /// a commad to division numbers
        /// command: div [number1] [number2] [variable]
        /// </summary>
        public static void Div()
        {
            string[] Parameters = GetParamters(line);
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            number1 = CheckIfVariable(number1);
            number2 = CheckIfVariable(number2);
            float result = float.Parse(number1) / float.Parse(number2);
            if (IsVariable(variable))
            {
                Variables[variable] = result.ToString();
                Console.WriteLine(result);
                Console.WriteLine(Variables[variable]);
                Console.WriteLine(number1);
                Console.WriteLine(number2);
                Console.WriteLine(variable);
            }
        }

        /// <summary>
        /// a command to read user keys
        /// command: input [variable]
        /// </summary>
        public static void Input()
        {
            string[] Parameters = GetParamters(line);
            string variable = Parameters[0];
            string input = Console.ReadLine();
            if (IsVariable(variable))
            {
                Variables[variable] = input;
            }
        }

        /// <summary>
        /// a command to set console title
        /// </summary>
        public static void Title()
        {
            string[] Parameters = GetParamters(line);
            Console.Title = Parameters[0].Replace('-', ' ');
        }

        /// <summary>
        /// a command to connect two words rogether 
        /// command: concat [word 1] [word 2] [variable]
        /// </summary>
        public static void Concat()
        {
            string[] Parameters = GetParamters(line);
            string word1 = Parameters[0];
            string word2 = Parameters[0];
            string variable = Parameters[0];
            word1 = CheckIfVariable(word1);
            word2 = CheckIfVariable(word2);
            string result = word1 + word2;
            if (IsVariable(variable))
            {
                Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a command to beep
        /// command: beep [frequency] [duration]
        /// </summary>
        public static void Beep()
        {
            string[] Parameters = GetParamters(line);
            Console.Beep(int.Parse(Parameters[0]), int.Parse(Parameters[1]));
        }

        /// <summary>
        /// a command to color text
        /// command: color [color]
        /// colors: green, blue, red, white, yellow, cyan, magenta, darkgreen, darkblue, darkred, gray
        /// </summary>
        public static void Color()
        {
            string[] Parameters = GetParamters(line);
            switch (Parameters[0])
            {
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "white":
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "magenta":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    break;
                case "darkgreen":
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case "darkblue":
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case "darkred":
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case "gray":
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }

        /// <summary>
        /// a command to clear text on console
        /// command: clear
        /// </summary>
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// a command to close the program
        /// command: close
        /// </summary>
        public static void Close()
        {
            LineIndex = lines.Length;
        }

        /// <summary>
        /// a command to pause the program
        /// command: pause
        /// </summary>
        public static void Pause()
        {
            Console.ReadKey();
        }

        /// <summary>
        /// a command to check if x =/!/</> x if so then go to line x
        /// command: if [variable 1] [operation =/!/</>] [variable 2] [line]
        /// </summary>
        public static void If()
        {
            string[] Parameters = GetParamters(line);
            string variable1 = Parameters[0];
            string operation = Parameters[1];
            string variable2 = Parameters[2];
            int gotoline = int.Parse(Parameters[3]);
            switch (operation)
            {
                case "=":
                    variable1 = CheckIfVariable(variable1);
                    variable2 = CheckIfVariable(variable2);
                    if (variable1 == variable2)
                    {
                        LineIndex = gotoline - 1;
                    }
                    break;
                case "!":
                    variable1 = CheckIfVariable(variable1);
                    variable2 = CheckIfVariable(variable2);
                    if (variable1 != variable2)
                    {
                        LineIndex = gotoline - 1;
                    }
                    break;
                case "<":
                    variable1 = CheckIfVariable(variable1);
                    variable2 = CheckIfVariable(variable2);
                    if (int.Parse(variable1) < int.Parse(variable2))
                    {
                        LineIndex = gotoline - 1;
                    }
                    break;
                case ">":
                    variable1 = CheckIfVariable(variable1);
                    variable2 = CheckIfVariable(variable2);
                    if (int.Parse(variable1) > int.Parse(variable2))
                    {
                        LineIndex = gotoline - 1;
                    }
                    break;
            }
        }
    }
}