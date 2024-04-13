//This defines the base screensurface, then also defines the console window.
using SadConsole.UI;

namespace AdventureGame.Scenes;

class RootScreen : ScreenObject
{
    private ScreenSurface _mainSurface;

    public RootScreen() 
    {
        _mainSurface = new ScreenSurface(GameSettings.GAME_WIDTH, GameSettings.GAME_HEIGHT);
        ControlsConsole console = new KeyboardHandlers();
        //Children.Add is akin to Unitys gameobject instantiation.
        Children.Add(_mainSurface);
        Children.Add(console);
    }
}
