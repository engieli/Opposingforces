using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;

[Category("Krasue")]
[Description("Moves the agent to the last known player position")]
public class MoveToLastSeenPosition : ActionTask<NavMeshAgent>
{
    public BBParameter<Vector3> lastSeenPosition;
    public BBParameter<float> stoppingDistance = 1f;

    protected override void OnExecute()
    {
        agent.isStopped = false;
        agent.SetDestination(lastSeenPosition.value);
    }

    protected override void OnUpdate()
    {
        if (!agent.pathPending && agent.remainingDistance <= stoppingDistance.value)
        {
            EndAction(true);
        }
    }

    protected override void OnStop()
    {
        agent.isStopped = true;
    }
}
