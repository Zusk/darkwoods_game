using System.Runtime.CompilerServices;
using AdventureGame;

public abstract class Item
{
    public string Name { get; set; }
    public string EnvironmentDescription { get; set; }
    //Wrap the name around SadConsole color tags.
    public string ColoredName(){
        return $"[c:r f:Lime]{Name}[c:undo]";
    }

    //Base constructor
    protected Item(string name, string envDescription)
    {
        Name = name;
        EnvironmentDescription = envDescription;
    }
    //This returns the enviorment description + the colored name.
    //Enviorment Desc is like -.. 'on the bank is a '
    //Name is 'fish'
    //So combined, its 'on the bank is a fish'
    public virtual string GetDisplayText()
    {
        return $"{EnvironmentDescription}{ColoredName()}.";
    }

    //Pickup function! Some items cant be picked up.
    public virtual string Pickup(Player player, Location location)
    {
        player.Inventory.Add(this);
        location.Items.Remove(this);
        return $"{GameStrings.PLAYER_ITEM_YOU_PICK_UP}{ColoredName()}.";
    }

    // Define a virtual method for use behavior
    public virtual string Use(Player player)
    {
        return GameStrings.PLAYER_CANT_USE_THAT_ITEM_HERE;
    }
}
