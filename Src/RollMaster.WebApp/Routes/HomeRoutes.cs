using RollMaster.WebApp.Controllers;
using TruSoft.StdLib.DependencyInjection;

namespace RollMaster.WebApp.Routes;

[Injectable(Lifetime=Lifetime.PerScope, As=[typeof(IRoute)])]
public class HomeRoutes : IRoute
{
    private readonly HomeController _homeController;

    public HomeRoutes(HomeController homeController)
    {
        _homeController = homeController;
    }
    
    public void Map(WebApplication app)
    {
        app.MapGet("/", _homeController.OnGetHomePage);
        app.MapGet("/home/test", _homeController.OnGetHtmxTestComponent);
    }
}
