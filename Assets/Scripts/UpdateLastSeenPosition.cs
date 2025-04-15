using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Krasue")]
[Description("Save the player's current position to 'lastSeenPosition' on the blackboard")]

public class UpdateLastSeenPosition : ActionTask
{
    public BBParameter<Transform> playerTransform;
    public BBParameter<Vector3> lastSeenPosition;
    public BBParameter<bool> hasSeenPlayerBefore; // Add the hasSeenPlayerBefore flag

    protected override void OnExecute()
    {
        if (playerTransform.value != null)
        {
            lastSeenPosition.value = playerTransform.value.position;
            hasSeenPlayerBefore.value = true; // Set the flag to true when the player is seen
        }
        EndAction(true);
    }
}
