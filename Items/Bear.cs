using AdventureGame;

//Feels weird to have bears be items, since technically they are more creatures or NPC's?
//We'd have to make a alternative set of very similar logic for creatures or NPC's.
public class Bear : Item
{
    public Bear() : base(GameStrings.ITEM_BEAR_NAME, GameStrings.ITEM_BEAR_ENV_DESC)
    {
    }

    public override string Pickup(Player player, Location location)
    {
        //You can't pick up a bear, silly!
        return GameStrings.ITEM_BEAR_DONT_PICK_ME_UP;
    }
}
