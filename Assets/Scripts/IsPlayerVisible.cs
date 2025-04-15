using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Krasue")]

public class IsPlayerVisible : ConditionTask<Transform>
{
    public BBParameter<Transform> playerTransform;
    public BBParameter<float> visionRange = 10f;
    public BBParameter<float> fieldOfView = 120f;

    protected override bool OnCheck()
    {
        if (playerTransform.value == null)
            return false;

        float distance = Vector3.Distance(agent.transform.position, playerTransform.value.position);
        return distance < visionRange.value;
    }

}
