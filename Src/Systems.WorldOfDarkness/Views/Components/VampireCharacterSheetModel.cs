using System.WorldOfDarkness;

namespace Systems.WorldOfDarkness.Views.Components;

public class VampireCharacterSheetModel : ICharacterSheetModel
{
    public string Name { get; set; }
    public string Player { get; set; }
    public WodSubSystem SubSystem { get; set;  }
}