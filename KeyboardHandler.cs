//This script is mostly from the SadConsole demo file, but I reworked it to remove functionality tied to the demo itself.
//Lots of these comments are from the original file! I just added a few to try to clarify how exactly this works.
using System.Security.Cryptography.X509Certificates;
using SadConsole.Components;
using SadConsole.UI;

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
        SadConsole.ColoredString directionList = SadConsole.ColoredString.Parser.Parse(GameWorld.Instance.Player.CurrentLocation.ListDirections());
        string commands = "                 COMMANDS: move [dir], help, cls, ver";

        // Combine them into one ColoredString
        SadConsole.ColoredString combinedText = new SadConsole.ColoredString(locationDescription) + " "
                                            + directionList
                                            + new SadConsole.ColoredString(commands);


        // Print the combined text
        cursor.Print(combinedText).NewLine();

        _keyboardHandlerDOS.Prompt = "Prompt> ";
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

        // Disable the cursor since our keyboard handler will do the work.
        Cursor cursor = _promptScreen.GetSadComponent<Cursor>()!;
        //'Is Ready' is a hardcoded bool in the keyboard handler script that determines if the component is valid.
        //_keyboardHandlerDOS.IsReady = false;
        //cursor.Print("Try typing in the following commands: help, ver, cls, look. If you type exit or quit, the program will end.").NewLine();
        //_keyboardHandlerDOS.Prompt = "Prompt> ";
        _keyboardHandlerDOS.IsReady = true;
        _promptScreen.Surface.TimesShiftedUp = 0;
    }

    //This is called by our KeyBoardHandler when we press enter.
    private void DOSHandlerEnterPressed(ClassicConsoleKeyboardHandler keyboardComponent, Cursor cursor, string value)
    {
        value = value.ToLower().Trim();
        System.Console.WriteLine(value);
        if (value.Equals("help"))
        {
            cursor.NewLine().
                        Print("  Advanced Example: Command Prompt - HELP").NewLine().
                        Print("  =======================================").NewLine().NewLine().
                        Print("  help       - Display this help info").NewLine().
                        Print("  ver        - Display version info").NewLine().
                        Print("  cls        - Clear the screen").NewLine().
                        Print("  look       - Look around in the current location").NewLine().
                        Print("  move [dir] - Move in a specified direction").NewLine().
                        Print("  directions - List possible directions to move").NewLine().
                        Print("  ").NewLine();
        }
        else if (value == "ver")
        {
            cursor.Print("2024. Made with SadConsole for MonoGame").NewLine();
        }
        else if (value == "cls")
        {
            _promptScreen.Clear();
            cursor.Position = new Point(0, 0);
            _keyboardHandlerDOS.CursorLastY = cursor.Position.Y;
        }
        else if (value.StartsWith("move "))
        {
            string directionString = value.Substring(5); // Assuming 'move ' is 5 characters
            if (Enum.TryParse<Direction>(directionString, true, out Direction direction))
            {
                var moveResult = GameWorld.Instance.Player.Move(direction);
                cursor.Print(SadConsole.ColoredString.Parser.Parse(moveResult.message)).NewLine();

                // Combine the description and the directions into one string
                string outputText = GameWorld.Instance.Player.CurrentLocation.GetDescription() + " " +
                                    GameWorld.Instance.Player.CurrentLocation.ListDirections();

                // Print the combined text
                PrinterText(cursor, keyboardComponent, outputText);
            }
            else
            {
                cursor.Print("Unknown direction").NewLine();
            }
        }
        else if (value == "look")
        {
            cursor.DisableWordBreak = false;

            // Combine the description and the directions into one string
            string outputText = GameWorld.Instance.Player.CurrentLocation.GetDescription() + " " +
                                GameWorld.Instance.Player.CurrentLocation.ListDirections();

            // Print the combined text
            PrinterText(cursor, keyboardComponent, outputText);

            cursor.DisableWordBreak = true;
        }
        else
        {
            cursor.Print("  Unknown command").NewLine();
        }
    }


    //This method uses 'Typing Instructions', a built in feature of SadConsole to facilitate animated text.
    private void PrinterText(Cursor _cursor, ClassicConsoleKeyboardHandler _keyboardComponent, String _string){
        //Define our instruction. This uses 'Draw String' - a instruction that gradually draws the text over time.
        var _typingInstruction = new SadConsole.Instructions
            .DrawString(SadConsole.ColoredString.Parser.Parse(_string));

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
