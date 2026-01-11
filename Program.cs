namespace ZFighters;

class Program
{
    static void Main(string[] args)
    {
        bool isRunning = true;
        List<ZFighter> zFighters = Utils.GetZFightersFromFile();

        while (isRunning)
        {
            DisplayMenu();
            string userInput = Console.ReadLine() ?? "";
            Console.WriteLine("");
            int choice = InputHandler.ValidateInput(userInput);

            switch (choice)
            {
                case 1:
                    DisplayAllZFighters(zFighters);
                    break;

                case 2:
                    AddZFighter(zFighters);
                    break;

                case 3:
                    Utils.SaveZFightersToFile(zFighters);
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

    public static void DisplayMenu()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("=        ZFighters       =");
        Console.WriteLine("==========================");
        Console.WriteLine("[1] Display all Z Fighters");
        Console.WriteLine("[2] Add a Z Fighter");
        Console.WriteLine("[3] Save existing Z Fighters");
        Console.WriteLine("[4] Quit");
        Console.Write("\nEnter your choice: ");
    }

    public static void DisplayAllZFighters(List<ZFighter> fighters)
    {
        foreach (var fighter in fighters)
        {
            Console.WriteLine(fighter);
        }
    }

    public static void AddZFighter(List<ZFighter> fighters)
    {
        try
        {
            Console.Write("Fighter's Name: ");
            string name = Console.ReadLine()!.Trim();
            InputHandler.ValidateName(name);

            Console.Write("Fighter's Race: ");
            string race = Console.ReadLine()!.Trim();
            InputHandler.ValidateRace(race);

            Console.Write("Fighter's Home Planet: ");
            string homePlanet = Console.ReadLine()!.Trim();
            InputHandler.ValidateHomePlanet(homePlanet);

            Console.Write("Fighter's Power Level: ");
            int powerLevel = int.Parse(Console.ReadLine()!);
            InputHandler.ValidatePowerLevel(powerLevel);
            
            Console.WriteLine("");

            fighters.Add(new(name, race, homePlanet, powerLevel));
            Console.WriteLine("");
        }
        catch (Exception ex)
        {
            InputHandler.HandleExceptions(ex);
        }
    }
}