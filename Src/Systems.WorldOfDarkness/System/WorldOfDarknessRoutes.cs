using RollMaster.Core.Web;
using Systems.WorldOfDarkness.Controllers;
using TruSoft.StdLib.DependencyInjection;

namespace Systems.WorldOfDarkness.System;

[Injectable( Lifetime = Lifetime.PerScope, As=[typeof(IHttpRouter)])]
public class WorldOfDarknessRoutes(WorldOfDarknessController controller) : IHttpRouter
{
    public void Map(WebApplication app)
    {
        app.MapGet("/wod-v5/new-character", controller.OnGetCreateCharacterPage);
    }
}