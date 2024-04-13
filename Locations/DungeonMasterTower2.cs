using System.Collections.Generic;
namespace AdventureGame;
public class DungeonMasterTower2 : Location
{
    public DungeonMasterTower2() : base("[c:r f:Cyan]Dungeon Master's Tower Summit[c:undo]")
    {
        // Initialize Dungeon Master's Tower Level 2 specific details here
    }

    public override string GetDescription()
    {
        return "You have ascended to the second level of the Dungeon Master's Tower. The air crackles with power here.";
    }
}
