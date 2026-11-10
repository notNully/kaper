namespace kap
{
    class MainClass
    {
        public static string filePath = string.Empty;
        public static string[] lines;
        public static int LineIndex = 0;
        public static string line = string.Empty;

        static public void Main(string[] args)
        {
            Initialization.Init(args);

            // a loop to go every line and run the commands
            while (LineIndex < lines.Length)
            {
                // get the current line
                line = lines[LineIndex];
                //gets the first word which is the caommnd for that line and runs a method for that command
                switch (StringMethods.GetLineFirstWord(line))
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
                    case "length":
                        Commands.Length();
                        break;
                    case "substring":
                        Commands.Substring();
                        break;
                    case "save":
                        Commands.Save();
                        break;
                    case "load":
                        Commands.Load();
                        break;
                }

                //goes to the next line
                LineIndex++;
            }
        }
    }
}