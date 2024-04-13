using System.Collections.Generic;
namespace AdventureGame;
public class DungeonMasterTower1 : Location
{
    public DungeonMasterTower1() : base("[c:r f:Cyan]Dungeon Master's Tower[c:undo]")
    {
        // Initialize Dungeon Master's Tower Level 1 specific details here
    }

    public override string GetDescription()
    {
        return "This is the first level of the Dungeon Master's Tower. It hums with arcane energy and the echoes of past battles.";
    }
}
