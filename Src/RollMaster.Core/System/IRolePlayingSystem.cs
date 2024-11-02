namespace RollMaster.Core.System;

public interface IRolePlayingSystem
{
    RolePlayingSystemInfo RolePlayingSystemInfo { get; }
    String CreateCharacterPagePath { get; }
    // public IResult GetEditCharacterComponent(CharacterSource source);
}