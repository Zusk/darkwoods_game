using AdventureGame;

public class Torch : Item
{
    public Torch() : base(GameStrings.ITEM_TORCH_NAME, GameStrings.ITEM_TORCH_ENV_DESC)
    {
    }
    public override string Use(Player player)
    {
        // Check if there's darkness in the player's current location
        Darkness darkness = player.CurrentLocation.GetItem<Darkness>();
        if (darkness != null)
        {
            //Remove the darkness with the torch
            player.CurrentLocation.Items.Remove(darkness);
            var gameWorld = GameWorld.Instance;
            //Add a key to the current location
            //player.CurrentLocation.AddNeighbor(Direction.North, gameWorld.Locations[GameStrings.MUSHROOM_CAVE_NAME]);
            Key key = new Key();
            player.CurrentLocation.AddItem(key);
            //Return a string that reveals the key.
            return key.GetDisplayText();
        }
        else
        {
            return GameStrings.PLAYER_CANT_USE_THAT_ITEM_HERE;
        }
    }
}
