using System;

namespace ZFighters;

public static class InputHandler
{
    public static int ValidateInput(string userInput)
    {
        try
        {
            return int.Parse(userInput);
        }
        catch (Exception exception)
        {
            HandleExceptions(exception);
            return -1;
        }
    }

    public static void ValidateName(string name)
    {
        if (name.Length <= 0)
        {
            throw new FormatException("Name cannot be an empty string");
        }
    }

    public static void ValidateRace(string race)
    {
        if (race.Length <= 0)
        {
            throw new FormatException("Race cannot be an empty string");
        }
    }

    public static void ValidateHomePlanet(string text)
    {
        if (text.Length <= 0)
        {
            throw new FormatException("Home Planet cannot be an empty string");
        }
    }

    public static void ValidatePowerLevel(int powerLevel)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(powerLevel);
    }

    public static void HandleExceptions(Exception ex)
    {
        if (ex is FormatException)
        {
            Console.WriteLine($"\n{ex.Message}");
            Console.WriteLine("Fighter not created\n");
            return;
        }
        
        if (ex is OverflowException)
        {
            Console.WriteLine($"\n{ex.Message}");
            Console.WriteLine("Fighter not created\n");
            return;
        }
        
        if (ex is ArgumentOutOfRangeException)
        {
            Console.WriteLine($"\n{ex.Message}");
            Console.WriteLine("Fighter not created\n");
            return;
        }
    }
}
