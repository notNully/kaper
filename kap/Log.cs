using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace kap
{
    internal class Log
    {
        public static string Logtext = "";
        static string pendingText = "";

        public static void AppendLog()
        {
            string filePath = Path.Combine(Path.GetDirectoryName(HelperMethods.filePath), "Log.txt");
            File.AppendAllText(filePath, pendingText);
            pendingText = "";
        }
        public static void logMsg(string text)
        {
            writeLog(text);
        }
        public static void logParameters(string[] Parameters, string command)
        {
            foreach (string param in Parameters)
            {
                writeLog($"{command}.{Array.IndexOf(Parameters, param)} {param}");
            }
        }
        
        public static void logError(string text, Exception exception)
        {
            writeLog(text);
            string[] ex = exception.Message.Split('\n');
            foreach (var msg in ex)
            {
                writeLog(msg, false);
            }
            Console.WriteLine(text, " (check logs for more info)");
        }
        static void writeLog(string text, bool withData = true)
        {
            string line;
            if (withData)
            {
                line = $"[{DateTime.Now}] Line.{MainClass.LineIndex}: {text}\n";
            }
            else
            {
                line = $"{text}\n";
            }
            Logtext += line;
            pendingText += line;
            AppendLog();
        }
        public static void PrintLog()
        {
            Console.Write(Logtext);
        }
    }
}