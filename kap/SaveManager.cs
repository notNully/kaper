
using System.Text.Json;

namespace kap;

static class SaveManager
{
    /// <summary>
    /// Creates a save file
    /// </summary>
    public static void CreateSaveFile(string name, string variableName)
    {
        try
        {
            Log.logMsg($"Creating save file: {name}.json");

            SaveFile save = new SaveFile();
            save.Name = name;
            save.Variables.Add(variableName, VariableManager.Variables[variableName]);

            string jsonString = JsonSerializer.Serialize(save);
            File.WriteAllText(name + ".json", jsonString);

            Log.logMsg("Save file created successfully");
        }
        catch (Exception ex)
        {
            Log.logError("Failed to create save file", ex);
            throw;
        }
    }

    /// <summary>
    /// Saves or updates a variable in a JSON file
    /// </summary>
    public static void SaveData(string name, string variableName)
    {
        string FileName = name + ".json";

        try
        {
            Log.logMsg($"Saving variable '{variableName}'");

            if (File.Exists(FileName))
            {
                string jsonString = File.ReadAllText(FileName);
                SaveFile save = JsonSerializer.Deserialize<SaveFile>(jsonString);

                save.Variables[variableName] = VariableManager.Variables[variableName];

                jsonString = JsonSerializer.Serialize(save);
                File.WriteAllText(FileName, jsonString);
            }
            else
            {
                CreateSaveFile(name, variableName);
            }

            Log.logMsg("Variable saved successfully");
        }
        catch (Exception ex)
        {
            Log.logError("Failed to save variable", ex);
            throw;
        }
    }

    /// <summary>
    /// Loads a variable from a JSON file
    /// </summary>
    public static void LoadData(string name, string variableName, string Destination)
    {
        string FileName = name + ".json";

        try
        {
            Log.logMsg($"Loading variable '{variableName}'");

            if (!File.Exists(FileName))
            {
                Log.logMsg("Save file not found");
                return;
            }

            string jsonString = File.ReadAllText(FileName);
            SaveFile save = JsonSerializer.Deserialize<SaveFile>(jsonString);

            if (!save.Variables.ContainsKey(variableName))
            {
                Log.logMsg($"Variable '{variableName}' not found in save file");
                return;
            }

            if (!VariableManager.Variables.ContainsKey(Destination))
            {
                Log.logMsg($"Destination variable '{Destination}' does not exist");
                return;
            }

            VariableManager.Variables[Destination] = save.Variables[variableName];

            Log.logMsg("Variable loaded successfully");
        }
        catch (Exception ex)
        {
            Log.logError("Failed to load variable", ex);
            throw;
        }
    }
}
