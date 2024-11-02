using RollMaster.Core.System;
using TruSoft.StdLib.DependencyInjection;

namespace Systems.WorldOfDarkness.System;

[Injectable(Lifetime = Lifetime.PerScope, As = [typeof(IRolePlayingSystem)])]
public class WorldOfDarknessSystem(WorldOfDarknessRoutes worldOfDarknessRoutes) : IRolePlayingSystem
{
    public RolePlayingSystemInfo RolePlayingSystemInfo => new() { RolePlayingSystemId = "WoD_V5", RolePlayingSystemName = "World of Darkness 5th Edition" };
    public string CreateCharacterPagePath => "/wod-v5/new-character";
}