using TruSoft.StdLib.DependencyInjection;

namespace RollMaster.WebApp.Routes;

[Injectable(Lifetime = Lifetime.PerScope)]
public class RouteRegister
{
    private readonly IEnumerable<IRoute> _routes;

    public RouteRegister(IEnumerable<IRoute> routes)
    {
        _routes = routes;
    }

    public void Register(WebApplication app)
    {
        foreach (var route in _routes)
        {
            route.Map( app ); 
        }
    }
}
