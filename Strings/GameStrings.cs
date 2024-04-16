using System;
using System.Data;

namespace AdventureGame
{
    public static class GameStrings
    {
        // Alias keys as constants
        public const string ALIAS_KEY_TRAVEL = "travel";
        public const string ALIAS_KEY_HEAD = "head";
        public const string ALIAS_KEY_MV = "mv";
        public const string ALIAS_KEY_GO = "go";
        public const string ALIAS_KEY_M = "m";
        public const string ALIAS_KEY_LK = "lk";
        public const string ALIAS_KEY_L = "l";
        public const string ALIAS_KEY_SEE = "see";
        public const string ALIAS_KEY_INV = "inv";
        public const string ALIAS_KEY_I = "i";
        public const string ALIAS_KEY_BAG = "bag";
        public const string ALIAS_KEY_GET = "get";
        public const string ALIAS_KEY_PICK = "pick";
        public const string ALIAS_KEY_PICK_UP = "pick up";
        public const string ALIAS_KEY_GRAB = "grab";
        public const string ALIAS_KEY_P = "p";
        public const string ALIAS_KEY_US = "us";
        public const string ALIAS_KEY_U = "u";
        public const string ALIAS_KEY_UTILIZE = "utilize";
        public const string ALIAS_KEY_DIR = "dir";
        public const string ALIAS_KEY_D = "d";
        public const string ALIAS_KEY_COMPASS = "compass";
        public const string ALIAS_KEY_HLP = "hlp";
        public const string ALIAS_KEY_H = "h";
        public const string ALIAS_KEY_INFO = "info";
        public const string ALIAS_KEY_CLR = "clr";
        public const string ALIAS_KEY_CLEAR = "clear";
        public const string ALIAS_KEY_C = "c";
        public const string ALIAS_KEY_VER = "ver";
        public const string ALIAS_KEY_V = "v";
        public const string ALIAS_KEY_VERSION = "version";
        public const string ALIAS_KEY_ABOUT = "about";
        public const string ALIAS_KEY_BELOW = "below";
        public const string ALIAS_KEY_ABOVE = "above";
        public const string ALIAS_KEY_LEFT = "left";
        public const string ALIAS_KEY_RIGHT = "right";
        public const string ALIAS_KEY_N = "n";
        public const string ALIAS_KEY_S = "s";
        public const string ALIAS_KEY_E = "e";
        public const string ALIAS_KEY_W = "w";

        public static readonly Dictionary<string, string> CommandAliases = new Dictionary<string, string>
        {
            {ALIAS_KEY_TRAVEL, COMMAND_MOVE},
            {ALIAS_KEY_HEAD, COMMAND_MOVE},
            {ALIAS_KEY_MV, COMMAND_MOVE},
            {ALIAS_KEY_GO, COMMAND_MOVE},
            {ALIAS_KEY_M, COMMAND_MOVE},
            {ALIAS_KEY_LK, COMMAND_LOOK},
            {ALIAS_KEY_L, COMMAND_LOOK},
            {ALIAS_KEY_SEE, COMMAND_LOOK},
            {ALIAS_KEY_INV, COMMAND_INVENTORY},
            {ALIAS_KEY_I, COMMAND_INVENTORY},
            {ALIAS_KEY_BAG, COMMAND_INVENTORY},
            {ALIAS_KEY_GET, COMMAND_PICKUP},
            {ALIAS_KEY_PICK, COMMAND_PICKUP},
            {ALIAS_KEY_PICK_UP, COMMAND_PICKUP},
            {ALIAS_KEY_P, COMMAND_PICKUP},
            {ALIAS_KEY_GRAB, COMMAND_PICKUP},
            {ALIAS_KEY_US, COMMAND_USE},
            {ALIAS_KEY_U, COMMAND_USE},
            {ALIAS_KEY_UTILIZE, COMMAND_USE},
            {ALIAS_KEY_DIR, COMMAND_DIRECTIONS},
            {ALIAS_KEY_D, COMMAND_DIRECTIONS},
            {ALIAS_KEY_COMPASS, COMMAND_DIRECTIONS},
            {ALIAS_KEY_HLP, COMMAND_HELP},
            {ALIAS_KEY_H, COMMAND_HELP},
            {ALIAS_KEY_INFO, COMMAND_HELP},
            {ALIAS_KEY_CLR, COMMAND_CLS},
            {ALIAS_KEY_CLEAR, COMMAND_CLS},
            {ALIAS_KEY_C, COMMAND_CLS},
            {ALIAS_KEY_VER, COMMAND_VER},
            {ALIAS_KEY_V, COMMAND_VER},
            {ALIAS_KEY_VERSION, COMMAND_VER},
            {ALIAS_KEY_ABOUT, COMMAND_VER},
            {ALIAS_KEY_BELOW, Direction.Down.ToString()},
            {ALIAS_KEY_ABOVE, Direction.Up.ToString()},
            {ALIAS_KEY_LEFT, Direction.West.ToString()},
            {ALIAS_KEY_RIGHT, Direction.East.ToString()},
            {ALIAS_KEY_N, Direction.North.ToString()},
            {ALIAS_KEY_S, Direction.South.ToString()},
            {ALIAS_KEY_E, Direction.East.ToString()},
            {ALIAS_KEY_W, Direction.West.ToString()}
        };

        // Location names
        public const string DARK_WOOD_NAME = "[c:r f:Cyan]Dark Wood[c:undo]";
        public const string DUNGEON_MASTER_TOWER1_NAME = "[c:r f:Cyan]Dungeon Master's Tower[c:undo]";
        public const string DUNGEON_MASTER_TOWER2_NAME = "[c:r f:Cyan]Dungeon Master's Tower Summit[c:undo]";
        public const string GREAT_LAKE_NAME = "[c:r f:Cyan]Great Lake[c:undo]";
        public const string MUSHROOM_CAVE_NAME = "[c:r f:Cyan]Mushroom Caves[c:undo]";
        public const string RUINED_RIVER_NAME = "[c:r f:Cyan]Ruined River[c:undo]";

        // Location descriptions
        public const string DARK_WOOD_DESC = "The Dark Wood is dense and foreboding, the thick canopy above allows little light to reach the forest floor.";
        public const string DUNGEON_MASTER_TOWER1_DESC = "This is the first level of the Dungeon Master's Tower. It hums with arcane energy and the echoes of past battles.";
        public const string DUNGEON_MASTER_TOWER2_DESC = "You have ascended to the second level of the Dungeon Master's Tower. The air crackles with power here.";
        public const string GREAT_LAKE_DESC = "The Great Lake is a vast expanse of water that stretches to the horizon. The water is clear and tranquil.";
        public const string MUSHROOM_CAVE_DESC = "Mushroom Caves are damp and echo with the sounds of dripping water. The air is filled with the earthy scent of fungi.";
        public const string RUINED_RIVER_DESC = "The Ruined River flows through a landscape of decay, bearing witness to the remnants of a once-great civilization.";
        //Items
        public const string ITEM_TORCH_NAME = "Torch";
        public const string ITEM_TORCH_ENV_DESC = "Planted in the ground is a ";
        public const string ITEM_BEAR_ENV_DESC = "Blocking our path to the north is a hibernating ";
        public const string ITEM_BEAR_NAME = "Bear";
        public const string ITEM_BEAR_DONT_PICK_ME_UP = "You can't fit a whole [c:r f:Lime]Bear[c:undo] in your inventory!!";
        public const string ITEM_FISH_NAME = "Fish";
        public const string ITEM_FISH_ENV_DESC = "Flopping on the ground by the river is a fatty ";
        public const string ITEM_FISH_PICKUP = "The [c:r f:Lime]Fish[c:undo] is slimy and wiggles as you pick it up, but you manage to stuff it into your inventory.";
        public const string ITEM_FISH_USE = "You offer the [c:r f:Lime]Fish[c:undo] to the [c:r f:Lime]Bear[c:undo] as a gift so that you can head to the north. The [c:r f:Lime]Bear[c:undo] turns to you, gives a condescending look, and simply says [c:r f:Violet]\"Sorry, I am vegan.\"[c:undo] before walking away. The way [c:r f:Cyan]north[c:undo] is now clear.";
        
        // Utility text
        public const string LOCATION_CANT_GO_THAT_WAY = "You can't go that way.";
        public const string LOCATION_UNKNOWN_DIRECTION = "In an unknown direction";
        public const string LOCATION_NORTH = "To our [c:r f:Cyan]north[c:undo]";
        public const string LOCATION_SOUTH = "To our [c:r f:Cyan]south[c:undo]";
        public const string LOCATION_EAST = "To our [c:r f:Cyan]east[c:undo]";
        public const string LOCATION_WEST = "To our [c:r f:Cyan]west[c:undo]";
        public const string LOCATION_UP = "Above us [c:r f:Cyan](up)[c:undo]";
        public const string LOCATION_DOWN = "Below us [c:r f:Cyan](down)[c:undo]";
        public const string DESCRIPTION_PREFIX = "You are at the ";
        public const string MOVE_PREFIX = "You move ";
        public const string MOVE_POSTFIX = " to the ";
        public const string DIRECTION_INFIX = "is";
        public const string UNKNOWN_COMMAND = "You cannot do that. Type \"[c:r f:Cyan]help[c:undo]\" to get a list of commands";
        public const string GAME_NAME = "[c:g f:Violet:DodgerBlue:19]☆*~`{Darkwoods}`~*☆[c:undo]";
        public const string GAME_START_LIST_COMMANDS = "COMMANDS: [c:r f:Cyan]move [dir], help, cls, ver, pickup [item]. use [item][c:undo]";
        public const string PLAYER_INVENTORY_HEADER = "  Inventory List:";
        public const string PLAYER_INVENTORY_BAR = "  ===============";
        public const string PLAYER_INVENTORY_PREFIX = "  - ";
        public const string PLAYER_INVENTORY_NO_ITEMS = "No items in inventory.";
        public const string PLAYER_ITEM_YOU_PICK_UP = "You pick up the ";
        public const string PLAYER_CANT_USE_THAT_ITEM_HERE = "You cannot use that here.";
        public const string PLAYER_DONT_HAVE_A_ITEM = "You do not have a ";
        public const string PLAYER_NO_ITEM_NAMED_THAT_PREFIX = "There isn't an item named '";
        public const string PLAYER_NO_ITEM_NAMED_THAT_SUFFIX = "' here.";
        // Commands
        public const string COMMAND_USE = "use";
        public const string COMMAND_PICKUP = "pickup";
        public const string COMMAND_MOVE = "move";
        public const string COMMAND_DIRECTIONS = "directions";
        public const string COMMAND_LOOK = "look";
        public const string COMMAND_VER = "ver";
        public const string COMMAND_CLS = "cls";
        public const string COMMAND_HELP = "help";
        public const string COMMAND_INVENTORY = "inventory";
    }
}
