using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kap
{
    class HelperMethods
    {
        public static string filePath = string.Empty;

        /// <summary>
        /// to get the file lines 
        /// </summary>
        static public void GetfileLines(string[] args)
        {
            //to run a kap file there is two ways:
            //go to the folder that has the kap file and open cmd by right clicking and seclect 'open in terminal' then type 'kap file.kap'
            if (args.Length > 0)
            {
                filePath = args[0];

                if (File.Exists(filePath))
                {
                    if (Path.GetExtension(filePath) == ".kap")
                    {
                        MainClass.lines = File.ReadAllLines(filePath);
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
        }

        /// <summary>
        /// checks if we reached the last line on the file to end the program
        /// </summary>
        /// <returns>true is we didn't reach the end</returns>
        static public bool IsOnEnd()
        {
            bool Bool = false;
            if (MainClass.LineIndex < MainClass.lines.Length)
            {
                Bool = true;
            }
            return Bool;
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
            if (MainClass.Variables.ContainsKey(var))
            {
                var = MainClass.Variables[var];

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
            if (MainClass.Variables.ContainsKey(var))
            {
                ReturnBool = true;
            }
            return ReturnBool;
        }
    }
}
