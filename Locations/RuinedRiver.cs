using System.Collections.Generic;
namespace AdventureGame;
public class RuinedRiver : Location
{
    public RuinedRiver() : base("[c:r f:Cyan]Ruined River[c:undo]")
    {
        // Initialize Ruined River specific details here
    }

    public override string GetDescription()
    {
        return "The Ruined River flows through a landscape of decay, bearing witness to the remnants of a once-great civilization.";
    }
}
