namespace AdventureGame;

public class Player
{
    public Location CurrentLocation { get; private set; }

    public Player(Location startingLocation)
    {
        CurrentLocation = startingLocation;
    }

    // The Move method is used to change the player's current location based on the direction.
    // it returns a tuple containing the new location and the move result message.
    public (Location newLocation, string message) Move(Direction direction)
    {
        var moveResult = CurrentLocation.Move(direction);
        CurrentLocation = moveResult.newLocation;
        return moveResult;
    }
}
