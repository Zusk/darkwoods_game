using System.Collections.Generic;
namespace AdventureGame;
public class RuinedRiver : Location
{
    public RuinedRiver() : base(GameStrings.RUINED_RIVER_NAME)
    {
    }

    public override string GetDescription()
    {
        return GameStrings.RUINED_RIVER_DESC;
    }
}
