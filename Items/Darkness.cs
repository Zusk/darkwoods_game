using AdventureGame;

public class Darkness : Item
{
    public Darkness() : base(GameStrings.ITEM_DARKNESS, GameStrings.ITEM_DARKNESS_ENV_DESC)
    {
    }
    public override string Pickup(Player player, Location location)
    {
        return GameStrings.PLAYER_CANNOT_PICK_THAT_UP;
    }
}
