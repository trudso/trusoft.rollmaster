using Microsoft.AspNetCore.Http.HttpResults;
using RollMaster.WebApp.Views.Components;
using RollMaster.WebApp.Views.Pages;
using TruSoft.StdLib.DependencyInjection;

namespace RollMaster.WebApp.Controllers;

[Injectable(Lifetime = Lifetime.PerScope)]
public class HomeController
{
    public IResult OnGetHomePage(HttpContext context)
    {
        return new RazorComponentResult(typeof(Home));
    }

    public IResult OnGetHtmxTestComponent(HttpContext context)
    {
        return new RazorComponentResult(typeof(HtmxTestComponent));
    }
}
