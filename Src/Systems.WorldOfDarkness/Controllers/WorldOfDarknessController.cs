using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Systems.WorldOfDarkness.Views.Components;
using Systems.WorldOfDarkness.Views.Pages;
using TruSoft.StdLib.DependencyInjection;

namespace Systems.WorldOfDarkness.Controllers;

[Injectable( Lifetime = Lifetime.PerScope)]
public class WorldOfDarknessController( )
{
    public IResult OnGetCharacterCreationPage(HttpContext context)
    {
        return new RazorComponentResult(typeof(CharacterCreationPage));
    }

    public IResult OnPostCharacterCreationPage(HttpContext context, [FromBody] VampireCharacterSheetModel model)
    {
        var characterId = Guid.NewGuid(); // created character
         
        
        
        
        context.Response.Headers.Append("HX-Redirect", $"/characters/{characterId}");
        return Results.Empty;
    }
}