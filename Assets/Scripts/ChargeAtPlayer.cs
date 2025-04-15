using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Krasue")]
public class ChargeAtPlayer : ActionTask
{
    public BBParameter<Transform> playerTransform;
    public BBParameter<float> chargeSpeed = 10f;
    public BBParameter<float> chargeDuration = 1f;

    private Vector3 chargeDirection;
    private float timer;

    protected override void OnExecute()
    {
        if (playerTransform.value == null)
        {
            Debug.LogWarning("No player transform found!");
            EndAction(false);
            return;
        }

        chargeDirection = (playerTransform.value.position - agent.transform.position).normalized;
        timer = 0f;
    }

    protected override void OnUpdate()
    {
        timer += Time.deltaTime;
        agent.transform.position += chargeDirection * chargeSpeed.value * Time.deltaTime;

        if (timer >= chargeDuration.value)
        {
            EndAction(true);
        }
    }
}
