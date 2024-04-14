using System.Collections.Generic;
namespace AdventureGame;
public class DungeonMasterTower1 : Location
{
    public DungeonMasterTower1() : base(GameStrings.DUNGEON_MASTER_TOWER1_NAME)
    {
    }

    public override string GetDescription()
    {
        return GameStrings.DUNGEON_MASTER_TOWER1_DESC;
    }
}
