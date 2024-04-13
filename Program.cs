//Default Program provided by SadConsole. This facilitates some base functionality of the SadConsole app.
using SadConsole.Configuration;

//This is where we define our window title.
Settings.WindowTitle = "https://github.com/Zusk/darkwoods_game";

//This is where we assign our screen size, starting screen, and if the screen is focused.
Builder gameStartup = new Builder()
    .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
    .SetStartingScreen<AdventureGame.Scenes.RootScreen>()
    .IsStartingScreenFocused(true)
    .ConfigureFonts(true)
    ;

//Backend functionality to create the window.
Game.Create(gameStartup);
Game.Instance.Run();
//Cleanup method
Game.Instance.Dispose();
