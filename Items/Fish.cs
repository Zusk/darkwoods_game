using AdventureGame;

public class Fish : Item
{
    public Fish() : base(GameStrings.ITEM_FISH_NAME, GameStrings.ITEM_FISH_ENV_DESC)
    {
    }

    public override string Pickup(Player player, Location location)
    {
        player.Inventory.Add(this);
        location.Items.Remove(this);
        return GameStrings.ITEM_FISH_PICKUP;
    }

    public override string Use(Player player)
    {
        // Check if there's a bear in the player's current location
        Bear bear = player.CurrentLocation.GetItem<Bear>();
        if (bear != null)
        {
            // If bear is present, remove it and allow passage
            //Bears fine, he just finds somewhere else to nap.
            player.CurrentLocation.Items.Remove(bear);
            var gameWorld = GameWorld.Instance;
            //Ths mushroom caves are north of the dark woods. By getting the bear to run away, we can go up north.
            //We do this by creating a neighbor connection from the players location - the darkwoods - to the mushroom cave.
            player.CurrentLocation.AddNeighbor(Direction.North, gameWorld.Locations[GameStrings.MUSHROOM_CAVE_NAME]);

            return GameStrings.ITEM_FISH_USE;
        }
        else
        {
            return GameStrings.PLAYER_CANT_USE_THAT_ITEM_HERE;
        }
    }
}
