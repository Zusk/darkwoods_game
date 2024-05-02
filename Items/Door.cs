using AdventureGame;

public class Door : Item
{
    public Door() : base(GameStrings.ITEM_DOOR, GameStrings.ITEM_DOOR_ENV_DESC)
    {
    }
    public override string Pickup(Player player, Location location)
    {
        return GameStrings.PLAYER_CANNOT_PICK_THAT_UP;
    }
}
