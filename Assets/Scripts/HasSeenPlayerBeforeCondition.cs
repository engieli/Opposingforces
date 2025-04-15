using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Krasue")]
public class HasSeenPlayerBeforeCondition : ConditionTask
{
    public BBParameter<bool> hasSeenPlayerBefore; // Blackboard variable to store the state of seeing the player

    protected override string info => "Checking if the player has been seen before";

    protected override bool OnCheck()
    {
        // Return true if the player has been seen before
        return hasSeenPlayerBefore.value;
    }
}
