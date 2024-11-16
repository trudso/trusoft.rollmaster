using System.WorldOfDarkness;
using TruSoft.StdLib.ChangeSets;
using TruSoft.StdLib.Exceptions;

namespace Systems.WorldOfDarkness.Test.ChangeSets;

public class CharacterMergeConflictTest
{
    [Fact]
    public void NameChangeConflictTest()
    {
        var conflictLogic = new ChangeConflictLogic();
        var rebaseLogic = new ChangeSetRebaseLogic(conflictLogic);
        
        var version1 = new WodCharacterVersion { Name = "BaseName" };
        var user1Change = new WodCharacterVersionChangeSet(version1);
        var user2Change = new WodCharacterVersionChangeSet(version1); 
        
        user1Change.Name.Set( "User1_Name");
        user2Change.Name.Set( "User2_Name");

        // user1Version is the new remote version
        var user1Version = user1Change.Apply();

        // attempt rebasing
        Assert.Throws<UnresolvedConflictsException>(() => rebaseLogic.Rebase(user2Change, user1Version, []));
        var conflicts = conflictLogic.FindConflicts(user2Change, user1Version).ToList();
        Assert.Single(conflicts);
        Assert.IsType<ValueChangeConflict>(conflicts.Single());
        
        // resolve conflicts with local winner
        var c1 = (ValueChangeConflict)conflicts.Single();
        var user2VersionRebased = rebaseLogic.Rebase(user2Change, user1Version, [new LocalWinnerConflictResolution() {
            ChangeId = c1.ChangeId,
            RemoteValue = c1.RemoteValue,
            LocalBaseValue = c1.LocalBaseValue
        }]);

        // verify values
        Assert.Equal("User2_Name", user2VersionRebased.Name.Get());
        Assert.Equal("User1_Name", user2VersionRebased.Name.OriginalValue);

        // apply the rebased changed and verify values
        var user2Version = user2VersionRebased.Apply();
        Assert.Equal("User2_Name", user2Version?.Name);
    }
}