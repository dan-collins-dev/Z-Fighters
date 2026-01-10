class ZFighter {
    public string Name { get; set; }
    public string Race { get; set; }
    public string HomePlanet { get; set; }
    public int PowerLevel { get; set; }

    public ZFighter(string name, string race, string homePlanet, int powerLevel)
    {
        Name = name;
        Race = race;
        HomePlanet = homePlanet;
        PowerLevel = powerLevel;
    }

    public override string ToString()
    {
        return $"Name: {Name}\n Race: {Race}\n Home Planet: {HomePlanet}\n Power Level: {PowerLevel}\n";
    }
}