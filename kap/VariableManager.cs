namespace kap;

static class VariableManager
{
    /// <summary>
    /// list to store the variables that are made
    /// </summary>
    public static Dictionary<string, string> Variables = new Dictionary<string, string>();

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
}