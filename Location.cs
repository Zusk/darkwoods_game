using System;
using System.Collections.Generic;
namespace AdventureGame;

/// <summary>
/// Represents a location in the adventure game. This is an abstract base class.
/// </summary>
public abstract class Location
{
    public string Name { get; set; }
    public Dictionary<Direction, Location> Neighbors { get; set; }

    /// <summary>
    /// Constructor for the location.
    /// </summary>
    /// <param name="name">The name of the location.</param>
    protected Location(string name)
    {
        Name = name;
        Neighbors = new Dictionary<Direction, Location>();
    }

    /// <summary>
    /// Adds a neighboring location to this location.
    /// </summary>
    /// <param name="direction">The direction in which the neighbor is located.</param>
    /// <param name="neighbor">The neighboring location.</param>
    public void AddNeighbor(Direction direction, Location neighbor)
    {
        Neighbors[direction] = neighbor;
    }

    /// <summary>
    /// Returns a description of the location.
    /// Format: "You are at the [Location Name]."
    /// </summary>
    /// <returns>Description of the location.</returns>
    public virtual string GetDescription()
    {
        return $"{GameStrings.DESCRIPTION_PREFIX}{Name}.";
    }

    /// <summary>
    /// Lists all directions from the current location to its neighbors.
    /// Format: "[Direction] is [Neighbor Name], [Direction] is [Neighbor Name], ..."
    /// </summary>
    /// <returns>Comma-separated string listing all accessible directions and their corresponding locations.</returns>
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

    /// <summary>
    /// Converts a Direction enum value to a string representation using game constants.
    /// </summary>
    /// <param name="direction">The direction to convert.</param>
    /// <returns>Formatted string indicating the direction.</returns>
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

    /// <summary>
    /// Attempts to move the player to a neighboring location in the specified direction.
    /// Returns a tuple containing the new location and a movement message.
    /// Format: "You move [Direction] to the [Location Name]."
    /// If movement is not possible, returns a message "You can't go that way."
    /// </summary>
    /// <param name="direction">The direction in which to move.</param>
    /// <returns>A tuple with the new location and a descriptive movement message.</returns>
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
}
