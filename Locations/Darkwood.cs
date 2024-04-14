using System.Collections.Generic;
namespace AdventureGame;

public class Darkwood : Location
{
    public Darkwood() : base(GameStrings.DARK_WOOD_NAME)
    {
    }

    public override string GetDescription()
    {
        return GameStrings.DARK_WOOD_DESC;
    }
}