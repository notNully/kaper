using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kap
{
    class Commands
    {
        /// <summary>
        /// a Command to go to a line
        /// command: goto [line:number]
        /// </summary>
        static public void Goto()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "goto");
            int targetLine = int.Parse(Parameters[0]);
            Log.logMsg("target line: " + targetLine);
            MainClass.LineIndex = targetLine - 1;
        }

        /// <summary>
        /// a command to print text on a screen
        /// command: print [T/F new line] [text]
        /// </summary>
        static public void Print()
        {
            string text = MainClass.line.Substring(8);
            text = HelperMethods.CheckIfVariable(text);
            Log.logMsg("text: " + text);
            if (MainClass.line.Substring(6, 1) == "F")
            {
                Log.logMsg("no new line");
                Console.Write(text);
            }
            else if (MainClass.line.Substring(6, 1) == "T")
            {
                Log.logMsg("new line");
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
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "var");
            string Name = Parameters[0];
            string value = Parameters[1];
            if (HelperMethods.IsVariable(Name))
            {
                Log.logMsg(Name + " already exists, overwriting it");
                MainClass.Variables.Remove(Name);
                MainClass.Variables.Add(Name, value.Replace("-", " "));
            }
            else
            {
                Log.logMsg("creating new variable " + Name);
                MainClass.Variables.Add(Name, value.Replace("-", " "));
            }
        }

        /// <summary>
        /// a command to modify a variable value
        /// command: set [variable Name] [value]
        /// </summary>
        static public void Set()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "set");
            string Name = Parameters[0];
            string value = Parameters[1];
            value = HelperMethods.CheckIfVariable(value);
            Log.logMsg("value: " + value);
            if (HelperMethods.IsVariable(Name))
            {
                Log.logMsg(Name + " is a variable");
                MainClass.Variables[Name] = value;
            }
        }

        /// <summary>
        /// a command to wait
        /// command: delay [miliseconds]
        /// </summary>
        static public void Delay()
        {
            string Paramter = MainClass.line.Substring(6);
            Log.logMsg("delay: " + Paramter);
            System.Threading.Thread.Sleep(int.Parse(Paramter));
        }

        /// <summary>
        /// a command to make a random number
        /// command: random [min] [max] [variable]
        /// </summary>
        public static void Random()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "random");
            string min = Parameters[0];
            string max = Parameters[1];
            string variable = Parameters[2];
            if (HelperMethods.IsVariable(variable))
            {
                Random random = new Random();
                int result = random.Next(int.Parse(min), int.Parse(max));
                Log.logMsg("result: " + result);
                MainClass.Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a commad to add numbers
        /// command: add [number1] [number2] [variable]
        /// </summary>
        public static void Add()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "add");
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            int result = 0;
            number1 = HelperMethods.CheckIfVariable(number1);
            number2 = HelperMethods.CheckIfVariable(number2);
            Log.logMsg("number 1: " + number1);
            Log.logMsg("number 2: " + number2);

            try
            {
                result = int.Parse(number1) + int.Parse(number2);
            }
            catch (DivideByZeroException ex)
            {
                Log.logError("Error: cant divied by zero", ex);
            }
            catch (FormatException ex)
            {
                Log.logError("Error: cant math with letters ", ex);
            }
            Log.logMsg("result: " + result);
            if (HelperMethods.IsVariable(variable))
            {
                Log.logMsg(variable + " is a variable");
                MainClass.Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a command to subtrac numbers
        /// command: sub [number1] [number2] [variable]
        /// </summary>
        public static void Sub()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "sub");
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            number1 = HelperMethods.CheckIfVariable(number1);
            number2 = HelperMethods.CheckIfVariable(number2);
            Log.logMsg("number 1: " + number1);
            Log.logMsg("number 2: " + number2);

            int result = 0;
            try
            {
                result = int.Parse(number1) - int.Parse(number2);
            }
            catch (FormatException ex)
            {
                Log.logError("Error: cant math with letters ", ex);
            }
            Log.logMsg("result: " + result);
            if (HelperMethods.IsVariable(variable))
            {
                Log.logMsg(variable + " is a variable");
                MainClass.Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a commad to multiply numbers
        /// command: multi [number1] [number2] [variable]
        /// </summary>
        public static void Multi()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "multi");
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            number1 = HelperMethods.CheckIfVariable(number1);
            number2 = HelperMethods.CheckIfVariable(number2);
            Log.logMsg("number 1: " + number1);
            Log.logMsg("number 2: " + number2);

            int result = 0;
            try
            {
                result = int.Parse(number1) * int.Parse(number2);
            }
            catch (FormatException ex)
            {
                Log.logError("Error: cant math with letters ", ex);
            }
            Log.logMsg("result: " + result);
            if (HelperMethods.IsVariable(variable))
            {
                Log.logMsg(variable + " is a variable");
                MainClass.Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a commad to division numbers
        /// command: div [number1] [number2] [variable]
        /// </summary>
        public static void Div()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "div");
            string number1 = Parameters[0];
            string number2 = Parameters[1];
            string variable = Parameters[2];
            number1 = HelperMethods.CheckIfVariable(number1);
            number2 = HelperMethods.CheckIfVariable(number2);
            Log.logMsg("number 1: " + number1);
            Log.logMsg("number 2: " + number2);

            float result = 0;
            try
            {
                result = float.Parse(number1) / float.Parse(number2);
            }
            catch (FormatException ex)
            {
                Log.logError("Error: cant math with letters ", ex);
            }
            Log.logMsg("result: " + result);
            if (HelperMethods.IsVariable(variable))
            {
                Log.logMsg(variable + " is a variable");
                MainClass.Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a command to read user keys
        /// command: input [variable]
        /// </summary>
        public static void Input()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "input");
            string variable = Parameters[0];
            string input = Console.ReadLine();
            Log.logMsg("input received: " + input);
            if (HelperMethods.IsVariable(variable))
            {
                MainClass.Variables[variable] = input;
            }
        }

        /// <summary>
        /// a command to set console title
        /// </summary>
        public static void Title()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "title");
            Console.Title = Parameters[0].Replace('-', ' ');
            Log.logMsg("title set to: " + Console.Title);
        }

        /// <summary>
        /// a command to connect two words rogether 
        /// command: concat [word 1] [word 2] [variable]
        /// </summary>
        public static void Concat()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "concat");
            string word1 = Parameters[0];
            string word2 = Parameters[1];
            string variable = Parameters[2];
            word1 = HelperMethods.CheckIfVariable(word1);
            word2 = HelperMethods.CheckIfVariable(word2);
            Log.logMsg("word 1: " + word1);
            Log.logMsg("word 2: " + word2);
            string result = word1 + word2;
            Log.logMsg("result: " + result);
            if (HelperMethods.IsVariable(variable))
            {
                Log.logMsg(variable + " is a variable");
                MainClass.Variables[variable] = result.ToString();
            }
        }

        /// <summary>
        /// a command to beep
        /// command: beep [frequency] [duration]
        /// </summary>
        public static void Beep()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "beep");
            Console.Beep(int.Parse(Parameters[0]), int.Parse(Parameters[1]));
        }

        /// <summary>
        /// a command to color text
        /// command: color [color]
        /// colors: green, blue, red, white, yellow, cyan, magenta, darkgreen, darkblue, darkred, gray
        /// </summary>
        public static void Color()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "color");
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
                default:
                    Log.logMsg("unknown color: " + Parameters[0]);
                    break;
            }
        }

        /// <summary>
        /// a command to clear text on console
        /// command: clear
        /// </summary>
        public static void Clear()
        {
            Log.logMsg("clearing console");
            Console.Clear();
        }

        /// <summary>
        /// a command to close the program
        /// command: close
        /// </summary>
        public static void Close()
        {
            Log.logMsg("closing program");
            MainClass.LineIndex = MainClass.lines.Length;
        }

        /// <summary>
        /// a command to pause the program
        /// command: pause
        /// </summary>
        public static void Pause()
        {
            Log.logMsg("pausing, waiting for key press");
            Console.ReadKey();
        }

        /// <summary>
        /// a command to check if x =/!/</> x if so then go to line x
        /// command: if [variable 1] [operation =/!/</>] [variable 2] [line]
        /// </summary>
        public static void If()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "if");
            string variable1 = Parameters[0];
            string operation = Parameters[1];
            string variable2 = Parameters[2];
            int gotoline = int.Parse(Parameters[3]);
            switch (operation)
            {
                case "=":
                    variable1 = HelperMethods.CheckIfVariable(variable1);
                    variable2 = HelperMethods.CheckIfVariable(variable2);
                    Log.logMsg(variable1 + " = " + variable2 + " ?");
                    if (variable1 == variable2)
                    {
                        Log.logMsg("true, jumping to line " + gotoline);
                        MainClass.LineIndex = gotoline - 1;
                    }
                    break;
                case "!":
                    variable1 = HelperMethods.CheckIfVariable(variable1);
                    variable2 = HelperMethods.CheckIfVariable(variable2);
                    Log.logMsg(variable1 + " != " + variable2 + " ?");
                    if (variable1 != variable2)
                    {
                        Log.logMsg("true, jumping to line " + gotoline);
                        MainClass.LineIndex = gotoline - 1;
                    }
                    break;
                case "<":
                    variable1 = HelperMethods.CheckIfVariable(variable1);
                    variable2 = HelperMethods.CheckIfVariable(variable2);
                    Log.logMsg(variable1 + " < " + variable2 + " ?");
                    if (int.Parse(variable1) < int.Parse(variable2))
                    {
                        Log.logMsg("true, jumping to line " + gotoline);
                        MainClass.LineIndex = gotoline - 1;
                    }
                    break;
                case ">":
                    variable1 = HelperMethods.CheckIfVariable(variable1);
                    variable2 = HelperMethods.CheckIfVariable(variable2);
                    Log.logMsg(variable1 + " > " + variable2 + " ?");
                    if (int.Parse(variable1) > int.Parse(variable2))
                    {
                        Log.logMsg("true, jumping to line " + gotoline);
                        MainClass.LineIndex = gotoline - 1;
                    }
                    break;
            }
        }

        /// <summary>
        /// a command to get a length of a word
        /// command: length [word] [variable]
        /// </summary>
        public static void Length()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "length");
            string word = Parameters[0];
            string variable = Parameters[1];
            word = HelperMethods.CheckIfVariable(word);
            Log.logMsg("word: " + word);
            if (HelperMethods.IsVariable(variable))
            {
                Log.logMsg("length: " + word.Length);
                MainClass.Variables[variable] = word.Length.ToString();
            }
        }

        /// <summary>
        /// a command to substring a word
        /// command: substring [word] [startindex] [length] [variable]
        /// </summary>
        public static void Substring()
        {
            string[] Parameters = HelperMethods.GetParamters(MainClass.line);
            Log.logParameters(Parameters, "substring");
            string word = Parameters[0];
            string startIndex = Parameters[1];
            string Length = Parameters[2];
            string variable = Parameters[3];
            word = HelperMethods.CheckIfVariable(word);
            startIndex = HelperMethods.CheckIfVariable(startIndex);
            Length = HelperMethods.CheckIfVariable(Length);
            Log.logMsg("word: " + word);
            Log.logMsg("start index: " + startIndex);
            Log.logMsg("length: " + Length);
            if (HelperMethods.IsVariable(variable))
            {
                string result = word.Substring(int.Parse(startIndex), int.Parse(Length));
                Log.logMsg("result: " + result);
                MainClass.Variables[variable] = result;
            }
        }
    }
}