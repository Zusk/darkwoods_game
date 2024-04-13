using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SadConsole;

public static class AudioManager
{
    private static Song backgroundMusic;
    private static ContentManager contentManager;

    // Initialize the ContentManager using the correct MonoGame services
    public static void Initialize()
    {
        System.Console.WriteLine("Current Directory: " + Environment.CurrentDirectory);
        System.Console.WriteLine("Content Path: " + Path.Combine(Environment.CurrentDirectory, "net8.0/Database/Audio"));

        // Initialize the ContentManager with MonoGame services accessed via SadConsole's Game instance
        contentManager = new ContentManager(Game.Instance.MonoGameInstance.Services, "Database/Audio");
        LoadContent();
        PlayMusic();
    }

    private static void LoadContent()
    {
        try
        {
            backgroundMusic = contentManager.Load<Song>("main");
        }
        catch (Exception ex)
        {
            System.Console.WriteLine($"Error loading audio file: {ex}");
            throw; // Rethrow the exception to see the stack trace in the console
        }

    }

    public static void PlayMusic()
    {
        // Start playing the background music and set it to loop
        MediaPlayer.Play(backgroundMusic);
        MediaPlayer.IsRepeating = true;
    }
}
