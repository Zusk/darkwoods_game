using System;
using System.Data;

namespace AdventureGame
{
    public static class GameStrings
    {
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
        public const string UNKNOWN_COMMAND = "You cannot do that. Type \"[c:r f:Cyan]help[c:undo]\" to get a list of commands";
        public const string GAME_NAME = "[c:r f:Violet]☆*~`{Darkwoods}`~*☆[c:undo]";
        public const string GAME_START_LIST_COMMANDS = "                 COMMANDS: [c:r f:Cyan]move [dir], help, cls, ver[c:undo]";
        // Commands
        public const string COMMAND_MOVE = "move";
        public const string COMMAND_DIRECTIONS = "directions";
        public const string COMMAND_LOOK = "look";
        public const string COMMAND_VER = "ver";
        public const string COMMAND_CLS = "cls";
        public const string COMMAND_HELP = "help";
    }
}
