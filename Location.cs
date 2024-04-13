using System;
using System.Collections.Generic;
namespace AdventureGame;

// Base class for locations
public abstract class Location
{
    public string Name { get; set; }
    public Dictionary<Direction, Location> Neighbors { get; set; }

    protected Location(string name)
    {
        Name = name;
        Neighbors = new Dictionary<Direction, Location>();
    }

    // Add a neighbor to the location
    public void AddNeighbor(Direction direction, Location neighbor)
    {
        Neighbors[direction] = neighbor;
    }

    // Method to get a description of the location
    public virtual string GetDescription()
    {
        return $"You are at the {Name}.";
    }

    // New method to list directions
    public string ListDirections()
    {
        var directions = new List<string>();
        foreach (var neighbor in Neighbors)
        {
            string directionText = DirectionToString(neighbor.Key);
            directions.Add($"{directionText} is {neighbor.Value.Name}");
        }
        return string.Join(", ", directions);
    }

    // Helper method to convert Direction enum to a readable string
    private string DirectionToString(Direction direction)
    {
        return direction switch
        {
            Direction.North => "To our [c:r f:Cyan]north[c:undo]",
            Direction.South => "To our [c:r f:Cyan]south[c:undo]",
            Direction.East => "To our [c:r f:Cyan]east[c:undo]",
            Direction.West => "To our [c:r f:Cyan]west[c:undo]",
            Direction.Up => "Above us",
            Direction.Down => "Below us",
            _ => "In an unknown direction"
        };
    }

    // Method to navigate to a neighbor
    // Returns a tuple containing the new Location and a message about the move
    public (Location newLocation, string message) Move(Direction direction)
    {
        if (Neighbors.ContainsKey(direction))
        {
            return (Neighbors[direction], $"You move {direction} to the {Neighbors[direction].Name}.");
        }
        else
        {
            return (this, "You can't go that way.");
        }
    }
}
