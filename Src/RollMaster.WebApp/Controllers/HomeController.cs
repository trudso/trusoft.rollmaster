using Microsoft.AspNetCore.Http.HttpResults;
using RollMaster.Core.System;
using RollMaster.WebApp.Views.Pages;
using TruSoft.StdLib.DependencyInjection;

namespace RollMaster.WebApp.Controllers;

[Injectable(Lifetime = Lifetime.PerScope)]
public class HomeController(IEnumerable<IRolePlayingSystem> rolePlayingSystems)
{
    public IResult OnGetHomePage(HttpContext context)
    {
        return new RazorComponentResult(typeof(Home));
    }

    public IResult OnGetCharacterCreationPage(HttpContext context)
    {
        var model = new CharacterCreationModel(rolePlayingSystems.Select(s => s.RolePlayingSystemInfo));
        return new RazorComponentResult(typeof(CharacterCreationPage), new Dictionary<string, object?>()
        {
            { "model", model }
        });
    }
    
    public IResult OnRedirectToCharacterCreationPage(HttpContext context, String systemId )
    {
        var system = rolePlayingSystems.SingleOrDefault( s => s.RolePlayingSystemInfo.RolePlayingSystemId == systemId );
        if ( system == null )
            throw new ArgumentException("No role playing system found with id " + systemId );

        context.Response.Headers.Append("HX-Redirect", system.CreateCharacterPagePath);
        return Results.Empty;
    }
}
