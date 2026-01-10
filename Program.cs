using System.Text.Json;

namespace ZFighters;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        List<ZFighter> zFighters = GetZFightersFromFile();

        while (isRunning)
        {
            DisplayMenu();
            string userInput = Console.ReadLine() ?? "";
            Console.WriteLine("");
            int choice = ValidateInput(userInput);

            switch (choice)
            {
                case 1:
                    DisplayAllZFighters(zFighters);
                    break;
                
                case 2:
                    AddZFighter(zFighters);
                    break;

                case 3:
                    SaveZFightersToFile(zFighters);
                    break;
                
                case 4:
                    isRunning = false;
                    break;
                
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
            
        }
    }

    public static List<ZFighter> GetZFightersFromFile()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, "data", "zfighters.json");

        string zFightersJsonString = File.ReadAllText(filePath);

        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        return JsonSerializer.Deserialize<List<ZFighter>>(zFightersJsonString, options)!;
    }

    public static void SaveZFightersToFile(List<ZFighter> fighters)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDirectory, "data", "zfighters.json");

        JsonSerializerOptions options = new()
        {
            PropertyNameCaseInsensitive = true
        };

        string stringifiedFighters = JsonSerializer.Serialize<List<ZFighter>>(fighters, options);
        File.WriteAllText(filePath, stringifiedFighters);
    }

    public static void AddZFighter(List<ZFighter> fighters)
    {
        try
        {
            Console.Write("Fighter's Name: ");
            string name = Console.ReadLine()!;
            Console.Write("Fighter's Race: ");
            string race = Console.ReadLine()!;
            Console.Write("Fighter's Home Planet: ");
            string homePlanet = Console.ReadLine()!;
            Console.Write("Fighter's PowerLevel: ");
            int powerLevel = int.Parse(Console.ReadLine()!);

            fighters.Add(new(name, race, homePlanet, powerLevel));
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Fighter not created");
            Console.WriteLine($"{ex.Message}");
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Fighter not created");
            Console.WriteLine($"{ex.Message}");
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("=        ZFighters       =");
        Console.WriteLine("==========================");
        Console.WriteLine("[1] Display All Z Fighters");
        Console.WriteLine("[2] Add a Z Fighter");
        Console.WriteLine("[3] Save existing Z Fighters");
        Console.WriteLine("[4] Quit");
    }

    public static void DisplayAllZFighters(List<ZFighter> fighters)
    {
        foreach (var fighter in fighters)
        {
            Console.WriteLine(fighter);
        }
    }

    static int ValidateInput(string userInput)
    {
        try
        {
            return int.Parse(userInput);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine($"\n{ex.Message}\n");
            return -1;
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"\n{ex.Message}\n");
            return -1;
        }
    }
}