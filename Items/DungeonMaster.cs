using AdventureGame;

public class DungeonMaster : Item
{
    public DungeonMaster() : base(GameStrings.ITEM_DUNGEON_MASTER, GameStrings.ITEM_DUNGEON_MASTER_ENV_DESC)
    {
    }
    public override string Pickup(Player player, Location location)
    {
        return GameStrings.ITEM_DUNGEON_MASTER_DONT_PICK_ME_UP;
    }
}
