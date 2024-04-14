using System.Collections.Generic;
namespace AdventureGame;
public class GreatLake : Location
{
    public GreatLake() : base(GameStrings.GREAT_LAKE_NAME)
    {
    }

    public override string GetDescription()
    {
        return GameStrings.GREAT_LAKE_DESC;
    }
}
