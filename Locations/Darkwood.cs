using System.Collections.Generic;
namespace AdventureGame;

public class Darkwood : Location
{
    public Darkwood() : base("[c:r f:Cyan]Dark Wood[c:undo]")
    {
        // Initialize Dark Wood specific details here
    }

    public override string GetDescription()
    {
        return "The Dark Wood is dense and foreboding, the thick canopy above allows little light to reach the forest floor.";
    }
}
