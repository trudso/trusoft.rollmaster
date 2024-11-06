using Microsoft.AspNetCore.Http.HttpResults;
using Systems.WorldOfDarkness.Views.Pages;
using TruSoft.StdLib.DependencyInjection;

namespace Systems.WorldOfDarkness.Controllers;

[Injectable( Lifetime = Lifetime.PerScope)]
public class WorldOfDarknessController
{
    public IResult OnGetCharacterCreationPage(HttpContext context)
    {
        return new RazorComponentResult(typeof(CharacterCreationPage));
    }
}