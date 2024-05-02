using AdventureGame;

public class Excalibur : Item
{
    public Excalibur() : base(GameStrings.ITEM_EXCALIBUR_NAME, GameStrings.ITEM_EXCALIBUR_ENV_DESC)
    {
    }
    public override string Pickup(Player player, Location location)
    {
        //You pick up excalibur, then reveal a path up into the tower
        var gameWorld = GameWorld.Instance;
        player.CurrentLocation.AddNeighbor(Direction.Up, gameWorld.Locations[GameStrings.DUNGEON_MASTER_TOWER2_NAME]);
        player.Inventory.Add(this);
        location.Items.Remove(this);
        return GameStrings.ITEM_EXCALIBUR_PICKUP;
    }
    public override string Use(Player player)
    {
        DungeonMaster dm = player.CurrentLocation.GetItem<DungeonMaster>();
        if (dm != null)
        {
            player.CurrentLocation.Items.Remove(dm);

            return GameStrings.GAME_WIN;
        }
        else
        {
            return GameStrings.PLAYER_CANT_USE_THAT_ITEM_HERE;
        }
    }
}
