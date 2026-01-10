using System.Text.Json;
namespace ZFighters;

public static class Utils
{
    private static string FilePath = Path.Combine(
        Directory.GetCurrentDirectory(), 
        "data", 
        "zfighters.json"
    );

    private static JsonSerializerOptions Options = new() {
        PropertyNameCaseInsensitive = true
    };

    public static List<ZFighter> GetZFightersFromFile()
    {
        string zFightersJsonString = File.ReadAllText(FilePath);

        return JsonSerializer.Deserialize<List<ZFighter>>(zFightersJsonString, Options)!;
    }

    public static void SaveZFightersToFile(List<ZFighter> fighters)
    {
        string stringifiedFighters = JsonSerializer.Serialize<List<ZFighter>>(fighters, Options);
        
        File.WriteAllText(FilePath, stringifiedFighters);
    }
}
