using System.Collections.Generic;
namespace AdventureGame;
public class DungeonMasterTower2 : Location
{
    public DungeonMasterTower2() : base(GameStrings.DUNGEON_MASTER_TOWER2_NAME)
    {
    }

    public override string GetDescription()
    {
        return GameStrings.DUNGEON_MASTER_TOWER2_DESC;
    }
}
