//This script is mostly from the SadConsole demo file, but I reworked it to remove functionality tied to the demo itself.
//Lots of these comments are from the original file! I just added a few to try to clarify how exactly this works.
using SadConsole.Components;
using SadConsole.UI;
using AdventureGame;

internal class KeyboardHandlers : ControlsConsole
{
    //private Player _player;
    //This is the screensurface we draw and manipulate through this script.
    private ScreenSurface _promptScreen;
    //This is where we set the keyboardHandler.
    private readonly ClassicConsoleKeyboardHandler _keyboardHandlerDOS;

    // This console domonstrates a classic MS-DOS or Windows Command Prompt style console.
    public KeyboardHandlers() : base(28, 4)
    {
        //'ClassicConsoleKeyboardHandler' is a object used by SadConsole to catch keyboard input and handle 'Terminal' like enter presses.
       _keyboardHandlerDOS = new ClassicConsoleKeyboardHandler("");

        // Create the other console where the keyboard handler will be set
        _promptScreen = new ScreenSurface(GameSettings.GAME_WIDTH - 6, GameSettings.GAME_HEIGHT - 6)
        {
            Position = (4, 4),
            UseKeyboard = true
        };

        // The keyboard handlers from the SadConsole.Extended library require a cursor to exist on
        // the object they're added to. Console and ControlsConsole always have a cursor. A standard
        // ScreenSurface doesn't. Also, this cursor is disabled, since we don't want it to handle
        // the keyboard and we want the handlers to do it.
        _promptScreen.SadComponents.Add(new Cursor() { IsEnabled = false });
        Border.CreateForSurface(_promptScreen, "");
        //Children.Add is shorthand by SadConsole, similar to Unitys gameobject creation.
        Children.Add(_promptScreen);

        _promptScreen.SadComponents.Add(_keyboardHandlerDOS);
        // Now that everything is created and ready, configure the handlers and prep the screens
        SetupHandlers();

        SetupAdventureGame();
    }

    public void SetupAdventureGame()
    {
        // This will initialize the GameWorld and set up all locations and the player
        var gameWorld = GameWorld.Instance;

        // Optionally, you can now access the GameWorld properties, such as Player and Locations
        // For example, to print the starting location description:
        Cursor cursor = _promptScreen.GetSadComponent<Cursor>()!;
        _keyboardHandlerDOS.IsReady = false;

        // Combine the strings
        string locationDescription = GameWorld.Instance.Player.CurrentLocation.GetDescription();
        SadConsole.ColoredString directionList = ParseColoredString(GameWorld.Instance.Player.CurrentLocation.ListDirections());

        cursor.Print(ParseColoredString(GameStrings.GAME_NAME)).NewLine();
        cursor.NewLine();

        // Combine them into one ColoredString
        SadConsole.ColoredString combinedText = ParseColoredString(locationDescription) + " "
                                            + directionList;


        // Print the combined text
        cursor.Print(combinedText).NewLine();
        cursor.Print(ParseColoredString(GameStrings.GAME_START_LIST_COMMANDS)).NewLine();

        _keyboardHandlerDOS.Prompt = "Prompt:";
        _keyboardHandlerDOS.IsReady = true;

    }

    public override void OnFocused()
    {
        // If this object is focused, move focus to the child object: _promptScreen.
        // This makes sure that _promptScreen receives keyboard input and not this
        // object
        _promptScreen.IsFocused = true;
    }

    //There is a bug tied to the above function, we use this to fix it :(. Talking with the manager behind the SadConsole repo to see if I can find a fix for this though.
    public override void Update(TimeSpan delta)
    {
        if(_promptScreen.IsFocused == false){
            _promptScreen.IsFocused = true;
        }
        base.Update(delta); // Call the original Update method, inside of that is where the animated text is drawn.
    }

    private void SetupHandlers()
    {
        // Our custom handler has a call back for processing the commands the user types. We could handle
        // this in any method object anywhere, but we've implemented it on this console directly.
        _keyboardHandlerDOS.EnterPressedAction = DOSHandlerEnterPressed;

        //_keyboardHandlerDOS.IsReady = false;
        // Disable the cursor since our keyboard handler will do the work.
        Cursor cursor = _promptScreen.GetSadComponent<Cursor>()!;
        cursor.DisableWordBreak = false;
        //'Is Ready' is a hardcoded bool in the keyboard handler script that determines if the component is valid.

        //_keyboardHandlerDOS.IsReady = false;
        //cursor.Print("Try typing in the following commands: help, ver, cls, look. If you type exit or quit, the program will end.").NewLine();
        //_keyboardHandlerDOS.Prompt = "Prompt :";
        _keyboardHandlerDOS.IsReady = true;
        _promptScreen.Surface.TimesShiftedUp = 0;
    }

    //This method is called by our KeyBoardHandler when the enter key is pressed.
    private void DOSHandlerEnterPressed(ClassicConsoleKeyboardHandler keyboardComponent, Cursor cursor, string value)
    {
        value = value.ToLower().Trim();
        System.Console.WriteLine(value);  // Output the trimmed, lowercased value for debugging.
        string outputText;

        switch (value)
        {
            case var command when command.StartsWith(GameStrings.COMMAND_PICKUP + " "):
                string itemName = command.Substring((GameStrings.COMMAND_PICKUP + " ").Length).Trim();
                Item? itemToPickup = GameWorld.Instance.Player.CurrentLocation.Items
                    .FirstOrDefault(item => item.Name.ToLower() == itemName);

                if (itemToPickup != null)
                {
                    string pickupResult = itemToPickup.Pickup(GameWorld.Instance.Player, GameWorld.Instance.Player.CurrentLocation);
                    cursor.Print(ParseColoredString(pickupResult)).NewLine();
                }
                else
                {
                    cursor.Print($"There isn't an item named '{itemName}' here.").NewLine();
                }
                break;

            case var command when command.StartsWith("use "):
                string useItemName = command.Substring(4).Trim(); // Extract the item name from the command
                Item? itemToUse = GameWorld.Instance.Player.Inventory
                    .FirstOrDefault(item => item.Name.ToLower() == useItemName);

                if (itemToUse != null)
                {
                    string useResult = itemToUse.Use(GameWorld.Instance.Player);
                    cursor.Print(useResult).NewLine();
                }
                else
                {
                    cursor.Print($"You don't have a {useItemName}.").NewLine();
                }
                break;

            case GameStrings.COMMAND_LOOK:
                // Handle the 'look' command: Provide a description of the current location along with available directions.
                outputText = GameWorld.Instance.Player.CurrentLocation.GetDescription() +
                            " " + GameWorld.Instance.Player.CurrentLocation.ListDirections();
                PrinterText(cursor, keyboardComponent, outputText);
                break;
            
            case GameStrings.COMMAND_DIRECTIONS:
                // Handle the 'directions' command: List all possible directions the player can move from the current location.
                outputText = GameWorld.Instance.Player.CurrentLocation.ListDirections();
                PrinterText(cursor, keyboardComponent, outputText);
                break;
            
            case var command when command.StartsWith(GameStrings.COMMAND_MOVE + " "):
                // Handle the 'move' command with a direction: Move the player in the specified direction if valid.
                string directionString = value.Substring(5); // Extract direction from command
                if (Enum.TryParse<Direction>(directionString, true, out Direction direction))
                {
                    var moveResult = GameWorld.Instance.Player.Move(direction);
                    cursor.Print(ParseColoredString(moveResult.message)).NewLine();
                    outputText = GameWorld.Instance.Player.CurrentLocation.GetDescription() +
                                " " + GameWorld.Instance.Player.CurrentLocation.ListDirections();
                    PrinterText(cursor, keyboardComponent, outputText);
                }
                else
                {
                    cursor.Print(GameStrings.LOCATION_CANT_GO_THAT_WAY).NewLine();
                }
                break;

            case GameStrings.COMMAND_INVENTORY:
                // Handle the 'inventory' command: List all items in the player's inventory.
                cursor.NewLine()
                    .Print(GameStrings.PLAYER_INVENTORY_HEADER).NewLine()
                    .Print(GameStrings.PLAYER_INVENTORY_BAR).NewLine();
                if (GameWorld.Instance.Player.Inventory.Count == 0)
                {
                    cursor.Print(GameStrings.PLAYER_INVENTORY_PREFIX + GameStrings.PLAYER_INVENTORY_NO_ITEMS).NewLine();
                }
                else
                {
                    foreach (Item item in GameWorld.Instance.Player.Inventory)
                    {
                        cursor.Print($"{GameStrings.PLAYER_INVENTORY_PREFIX}{item.Name}").NewLine();
                    }
                }
                break;

            case GameStrings.COMMAND_HELP:
                // Handle the 'help' command: Display a help menu with available commands.
                cursor.NewLine()
                    .Print("  Advanced Example: Command Prompt - HELP").NewLine()
                    .Print("  =======================================").NewLine().NewLine()
                    .Print("  help       - Display this help info").NewLine()
                    .Print("  ver        - Display version info").NewLine()
                    .Print("  cls        - Clear the screen").NewLine()
                    .Print("  look       - Look around in the current location").NewLine()
                    .Print("  move [dir] - Move in a specified direction").NewLine()
                    .Print("  directions - List possible directions to move").NewLine()
                    .Print("  ").NewLine();
                break;

            case GameStrings.COMMAND_VER:
                // Handle the 'ver' command: Display version information about the game.
                cursor.Print("2024. Made with SadConsole for MonoGame").NewLine();
                break;
                
            case GameStrings.COMMAND_CLS:
                // Handle the 'cls' command: Clear the console screen.
                _promptScreen.Clear();
                cursor.Position = new Point(0, 0);
                _keyboardHandlerDOS.CursorLastY = cursor.Position.Y;
                break;

            default:
                // Handle unknown commands: Display a message indicating that the command is unrecognized.
                cursor.Print(ParseColoredString(GameStrings.UNKNOWN_COMMAND)).NewLine();
                break;
        }
    }

    private static ColoredString ParseColoredString(string text)
    {
        return ColoredString.Parser.Parse(text);
    }

    //This method uses 'Typing Instructions', a built in feature of SadConsole to facilitate animated text.
    private void PrinterText(Cursor _cursor, ClassicConsoleKeyboardHandler _keyboardComponent, String _string){
        //Define our instruction. This uses 'Draw String' - a instruction that gradually draws the text over time.
        var _typingInstruction = new SadConsole.Instructions
            .DrawString(ParseColoredString(_string));

        //Define values of our instruction.
        _typingInstruction.Position = _cursor.Position;
        _typingInstruction.Cursor = _cursor;
        _typingInstruction.TotalTimeToPrint = TimeSpan.FromSeconds(4);
        //When the typing instruction is finished, call this event.
        _typingInstruction.Finished += _typingInstruction_Finished;
        _typingInstruction.RemoveOnFinished = true;
        _keyboardComponent.IsReady = false;
        //Add the instruction
        _promptScreen.SadComponents.Add(_typingInstruction);

        //Change our cursor position.
        _cursor.Position = new(_typingInstruction.Position.X, _typingInstruction.Position.Y + _string.Length);
    }

    private void _typingInstruction_Finished(object? sender, EventArgs e)
    {
        _keyboardHandlerDOS.IsReady = true;
    }
}
