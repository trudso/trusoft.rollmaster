using TruSoft.StdLib.DependencyInjection;

namespace RollMaster.Core.Web;

[Injectable(Lifetime = Lifetime.PerScope)]
public class RouteRegister
{
    private readonly IEnumerable<IHttpRouter> _httpRouters;

    public RouteRegister(IEnumerable<IHttpRouter> httpRouters)
    {
        _httpRouters = httpRouters;
    }

    public void Register(WebApplication app)
    {
        foreach (var route in _httpRouters)
        {
            route.Map( app ); 
        }
    }
}
