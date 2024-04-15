using AdventureGame;

public class GameWorld
{
    private static GameWorld? _instance;

    public Player Player { get; private set; }
    public Dictionary<string, Location> Locations { get; private set; }

    // Constructor is private so it can't be instantiated outside of this class
    private GameWorld()
    {
        Locations = new Dictionary<string, Location>();
        Player = new Player(new Darkwood());
        // Initialize the locations and the player here
    }

    // Public static method to get the instance of the class
    public static GameWorld Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameWorld();
                _instance.InitializeWorld();
            }
            return _instance;
        }
    }

    private void InitializeWorld()
    {
        // Create locations
        Location darkWood = new Darkwood();
        Location mushroomCaves = new MushroomCave();
        Location dungeonMasterTower1 = new DungeonMasterTower1();
        Location dungeonMasterTower2 = new DungeonMasterTower2();
        Location greatLake = new GreatLake();
        Location ruinedRiver = new RuinedRiver();

        // Set up neighbors
        darkWood.AddNeighbor(Direction.North, mushroomCaves);
        darkWood.AddNeighbor(Direction.West, greatLake);
        darkWood.AddNeighbor(Direction.South, ruinedRiver);
        darkWood.AddNeighbor(Direction.East, dungeonMasterTower1);
        darkWood.AddItem(new Torch());

        mushroomCaves.AddNeighbor(Direction.South, darkWood);
        greatLake.AddNeighbor(Direction.East, darkWood);
        ruinedRiver.AddNeighbor(Direction.North, darkWood);

        dungeonMasterTower1.AddNeighbor(Direction.West, darkWood);
        dungeonMasterTower1.AddNeighbor(Direction.Up, dungeonMasterTower2);
        dungeonMasterTower2.AddNeighbor(Direction.Down, dungeonMasterTower1);

        // Add locations to the dictionary with a unique key for each one
        Locations.Add("DarkWood", darkWood);
        Locations.Add("MushroomCaves", mushroomCaves);
        Locations.Add("DungeonMasterTower1", dungeonMasterTower1);
        Locations.Add("DungeonMasterTower2", dungeonMasterTower2);
        Locations.Add("GreatLake", greatLake);
        Locations.Add("RuinedRiver", ruinedRiver);

        // Initialize the player with a starting location
        Player = new Player(darkWood);
    }
}
