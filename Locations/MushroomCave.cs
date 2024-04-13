using System.Collections.Generic;
namespace AdventureGame;
public class MushroomCave : Location
{
    public MushroomCave() : base("[c:r f:Cyan]Mushroom Caves[c:undo]")
    {
        // Initialize Mushroom Caves specific details here
    }

    public override string GetDescription()
    {
        return "Mushroom Caves are damp and echo with the sounds of dripping water. The air is filled with the earthy scent of fungi.";
    }
}
