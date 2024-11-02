using RollMaster.Core.Web;
using RollMaster.WebApp.Controllers;
using TruSoft.StdLib.DependencyInjection;

namespace RollMaster.WebApp.Routes;

[Injectable(Lifetime=Lifetime.PerScope, As=[typeof(IHttpRouter)])]
public class HomeRouter : IHttpRouter
{
    private readonly HomeController _homeController;

    public HomeRouter(HomeController homeController)
    {
        _homeController = homeController;
    }
    
    public void Map(WebApplication app)
    {
        app.MapGet("/", _homeController.OnGetHomePage);
        app.MapGet("/new-character", _homeController.OnGetCreateCharacterPage);
        app.MapGet("/new-character/htmx/character-creation/{systemId}", _homeController.OnRedirectToCharacterCreationPage);
    }
}
