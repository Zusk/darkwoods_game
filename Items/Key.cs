using AdventureGame;

public class Key : Item
{
    public Key() : base(GameStrings.ITEM_KEY_NAME, GameStrings.ITEM_KEY_ENV_DESC)
    {
    }
    public override string Use(Player player)
    {
        // Check if there's a door
        Door door = player.CurrentLocation.GetItem<Door>();
        if (door != null)
        {
            player.CurrentLocation.Items.Remove(door);
            var gameWorld = GameWorld.Instance;

            player.CurrentLocation.AddItem(new Excalibur());
            return GameStrings.ITEM_KEY_USE;
        }
        else
        {
            return GameStrings.PLAYER_CANT_USE_THAT_ITEM_HERE;
        }
    }
}
