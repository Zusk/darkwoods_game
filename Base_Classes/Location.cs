using System;
using System.Collections.Generic;
namespace AdventureGame;

public abstract class Location
{
    public string Name { get; set; }
    protected string Description { get; set; }  // Store the specific description for each location
    public Dictionary<Direction, Location> Neighbors { get; set; }
    public List<Item> Items { get; private set; }

    protected Location(string name, string description)
    {
        Name = name;
        Description = description;
        Neighbors = new Dictionary<Direction, Location>();
        Items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    //This gets the description of the location, and adds the items in the location if any items are there.
    public virtual string GetDescription()
    {
        string fullDescription = $"{GameStrings.DESCRIPTION_PREFIX}{Name}. {Description}";
        if (Items.Count > 0)
        {
            fullDescription += " " + string.Join(" ", ListItems());
        }
        return fullDescription;
    }

    private IEnumerable<string> ListItems()
    {
        foreach (Item item in Items)
        {
            yield return item.GetDisplayText();
        }
    }

    public void AddNeighbor(Direction direction, Location neighbor)
    {
        Neighbors[direction] = neighbor;
    }

    public string ListDirections()
    {
        var directions = new List<string>();
        foreach (var neighbor in Neighbors)
        {
            string directionText = DirectionToString(neighbor.Key);
            directions.Add($"{directionText} {GameStrings.DIRECTION_INFIX} {neighbor.Value.Name}");
        }
        return string.Join(", ", directions);
    }

    private string DirectionToString(Direction direction)
    {
        return direction switch
        {
            Direction.North => GameStrings.LOCATION_NORTH,
            Direction.South => GameStrings.LOCATION_SOUTH,
            Direction.East => GameStrings.LOCATION_EAST,
            Direction.West => GameStrings.LOCATION_WEST,
            Direction.Up => GameStrings.LOCATION_UP,
            Direction.Down => GameStrings.LOCATION_DOWN,
            _ => GameStrings.LOCATION_UNKNOWN_DIRECTION
        };
    }

    //Format is...
    //[You move] [north] [to the] [Mushroom Cave]
    public (Location newLocation, string message) Move(Direction direction)
    {
        if (Neighbors.ContainsKey(direction))
        {
            return (Neighbors[direction], $"{GameStrings.MOVE_PREFIX}{direction}{GameStrings.MOVE_POSTFIX}{Neighbors[direction].Name}.");
        }
        else
        {
            return (this, GameStrings.LOCATION_CANT_GO_THAT_WAY);
        }
    }

    // Method to check if an item exists in the location by item name
    public bool HasItem(string itemName)
    {
        return Items.Any(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
    }

    // Overloaded method to check if an item exists in the location by Item object
    public bool HasItem(Type itemType)
    {
        return Items.Any(item => itemType.IsInstanceOfType(item));
    }

    // Generic method to get an item of a specific type from the location
    public T GetItem<T>() where T : Item
    {
        return Items.OfType<T>().FirstOrDefault();
    }

    // Method overload to get an item by its name
    public Item GetItem(string itemName)
    {
        return Items.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
    }
}
