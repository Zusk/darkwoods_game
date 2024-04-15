using AdventureGame;

public abstract class Item
{
    public string Name { get; set; }
    public string EnvironmentDescription { get; set; }

    protected Item(string name, string envDescription)
    {
        Name = name;
        EnvironmentDescription = envDescription;
    }

    public virtual string GetDisplayText()
    {
        return $"{EnvironmentDescription}{Name}.";
    }

    // Define a virtual method for pickup behavior
    public virtual string Pickup(Player player, Location location)
    {
        player.Inventory.Add(this);  // Add the item to the player's inventory
        location.Items.Remove(this); // Remove the item from the location
        return $"You pick up the {Name}.";
    }
}
