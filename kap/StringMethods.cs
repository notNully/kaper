using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kap;

static class StringMethods
{
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
}
