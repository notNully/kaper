namespace kap;

static class Initialization
{
    /// <summary>
    /// Initializ the program reads the file path and lines and stores it and checks if debug enabled
    /// </summary>
    public static void Init(string[] args)
    {
        GetfileLines(args);
        if (args.Length > 1)
        {
            if (args[1].ToLower() == "debug")
            {
                Log.isDebugEnabled = true;
            }
        }
        Log.AppendLog();
    }

    /// <summary>
    /// decodes the encyption on kap files
    /// </summary>
    /// <param name="base64EncodedData">add the encypted text</param>
    /// <returns>the decoded string</returns>
    static string Base64Decode(string base64EncodedData)
    {
        var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
        return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
    }

    /// <summary>
    /// to get the file lines 
    /// </summary>
    static void GetfileLines(string[] args)
    {
        //to run a kap file there is two ways:
        //go to the folder that has the kap file and open cmd by right clicking and seclect 'open in terminal' then type 'kap file.kap'
        if (args.Length > 0)
        {
            MainClass.filePath = args[0];
            Log.logMsg("file path provided: " + args[0]);
            if (File.Exists(MainClass.filePath))
            {
                Log.logMsg("file exists");
                if (Path.GetExtension(MainClass.filePath) == ".kap")
                {
                    Log.logMsg("loading .kap file");
                    MainClass.lines = File.ReadAllLines(MainClass.filePath);
                    Log.logMsg("loaded " + MainClass.lines.Length + " lines, decoding");
                    foreach (var line in MainClass.lines)
                    {
                        if (line != null)
                        {
                            int index = Array.IndexOf(MainClass.lines, line);
                            string decrypted = Base64Decode(line);
                            MainClass.lines[index] = decrypted;
                        }
                    }
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
                Console.ReadKey();
                Environment.Exit(0);
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
}


