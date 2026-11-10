using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KapBuilder
{

    class Builder
    {
        static string FilePath = "";
        static string[] lines;

        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                FilePath = args[0];

                if (File.Exists(FilePath))
                {
                    if (Path.GetExtension(FilePath) == ".kap")
                    {
                        Console.WriteLine("Error: File is already a kap file.");
                        Environment.Exit(0);
                    }
                    else
                    {
                        lines = File.ReadAllLines(FilePath);
                    }
                }
                else
                {
                    Console.WriteLine("Error: File not found.");
                    Environment.Exit(0);
                }
            }
            else
            {
                Console.WriteLine("Error: No file provided");
                Console.ReadKey();
                Environment.Exit(0);
            }

            foreach (string line in lines)
            {
                if (line != null)
                {
                    int index = Array.IndexOf(lines, line);
                    string encypted = Base64Encode(line);
                    lines[index] = encypted;
                }
            }
            if (File.Exists(Path.Combine(Path.GetDirectoryName(FilePath), Path.GetFileName(FilePath) + ".kap").Replace(".txt", "")))
            {
                File.Delete(Path.Combine(Path.GetDirectoryName(FilePath), Path.GetFileName(FilePath) + ".kap").Replace(".txt", ""));
            }
            
            File.AppendAllLines(Path.Combine(Path.GetDirectoryName(FilePath), Path.GetFileName(FilePath) + ".kap").Replace(".txt", ""), lines);
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
