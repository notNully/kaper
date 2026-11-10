namespace kap;

/// <summary>
/// Class for saving Variables to Json
/// </summary>
class SaveFile
{
    public string Name { get; set; }
    public Dictionary<string, string> Variables {  get; set; }

    public SaveFile()
    {
        Name = $"{DateTime.Now}_Generated_Json_Save_File";
        Variables = new Dictionary<string, string>();
    }
}
