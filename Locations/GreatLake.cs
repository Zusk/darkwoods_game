using System.Collections.Generic;
namespace AdventureGame;
public class GreatLake : Location
{
    public GreatLake() : base("[c:r f:Cyan]Great Lake[c:undo]")
    {
        // Initialize Great Lake specific details here
    }

    public override string GetDescription()
    {
        return "The Great Lake is a vast expanse of water that stretches to the horizon. The water is clear and tranquil.";
    }
}
