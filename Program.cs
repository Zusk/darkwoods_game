using SadConsole;
using SadConsole.Configuration;

class Program
{
    static void Main(string[] args)
    {
        // Setup SadConsole configuration
        Settings.WindowTitle = "Darkwoods Game";
        var gameStartup = new Builder()
            .SetScreenSize(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT)
            .SetStartingScreen<AdventureGame.Scenes.RootScreen>()
            .IsStartingScreenFocused(true)
            .ConfigureFonts(true);

        // Create and start the game
        Game.Create(gameStartup);

        // Initialize AudioManager after Game has been created
        AudioManager.Initialize();

        // Run the game
        Game.Instance.Run();
        Game.Instance.Dispose();
    }
}
