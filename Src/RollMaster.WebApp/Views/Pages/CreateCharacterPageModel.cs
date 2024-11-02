using RollMaster.Core.System;

namespace RollMaster.WebApp.Views.Pages;

public class CreateCharacterPageModel(IEnumerable<RolePlayingSystemInfo> rolePlayingSystemInfos)
{
    public IEnumerable<RolePlayingSystemInfo> RolePlayingSystemInfos { get; } = rolePlayingSystemInfos;
}