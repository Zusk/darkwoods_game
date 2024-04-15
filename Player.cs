using System;
using System.Collections.Generic;

namespace AdventureGame
{
    public class Player
    {
        public Location CurrentLocation { get; private set; }
        public List<Item> Inventory { get; private set; } // Inventory list to store items

        public Player(Location startingLocation)
        {
            CurrentLocation = startingLocation;
            Inventory = new List<Item>(); // Initialize the inventory
        }

        // The Move method is used to change the player's current location based on the direction.
        // It returns a tuple containing the new location and the move result message.
        public (Location newLocation, string message) Move(Direction direction)
        {
            var moveResult = CurrentLocation.Move(direction);
            CurrentLocation = moveResult.newLocation;
            return moveResult;
        }

        // Add an item to the player's inventory
        public void AddItem(Item item)
        {
            Inventory.Add(item);
        }

        // Remove an item from the player's inventory
        public bool RemoveItem(Item item)
        {
            return Inventory.Remove(item);
        }
    }
}
