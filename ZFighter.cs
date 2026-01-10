namespace ZFighters;

public class ZFighter(string name, string race, string homePlanet, int powerLevel)
{
    public string Name { get; set; } = name;
    public string Race { get; set; } = race;
    public string HomePlanet { get; set; } = homePlanet;
    public int PowerLevel { get; set; } = powerLevel;

    public override string ToString()
    {
        return $"Name: {Name}\n Race: {Race}\n Home Planet: {HomePlanet}\n Power Level: {PowerLevel}\n";
    }
}