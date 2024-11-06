using RollMaster.Core.System;

namespace RollMaster.WebApp.Views.Pages;

public class CharacterCreationModel(IEnumerable<RolePlayingSystemInfo> rolePlayingSystemInfos)
{
    public IEnumerable<RolePlayingSystemInfo> RolePlayingSystemInfos { get; } = rolePlayingSystemInfos;
}