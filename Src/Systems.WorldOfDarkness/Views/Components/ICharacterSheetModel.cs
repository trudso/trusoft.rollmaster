using System.WorldOfDarkness;

namespace Systems.WorldOfDarkness.Views.Components;

public interface ICharacterSheetModel
{
    string Name { get; set; }
    WodSubSystem SubSystem { get; set; }
}