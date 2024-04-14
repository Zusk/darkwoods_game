using System.Collections.Generic;
namespace AdventureGame;
public class MushroomCave : Location
{
    public MushroomCave() : base(GameStrings.MUSHROOM_CAVE_NAME)
    {
    }

    public override string GetDescription()
    {
        return GameStrings.MUSHROOM_CAVE_DESC;
    }
}
