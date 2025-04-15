using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Krasue")]
public class TelegraphCharge : ActionTask
{
    public BBParameter<float> telegraphTime = 1.5f;
    public BBParameter<Color> telegraphColor = Color.red;

    private Renderer rend;
    private Color originalColor;
    private float timer;

    protected override void OnExecute()
    {
        rend = agent.GetComponentInChildren<Renderer>();

        if (rend != null)
        {
            originalColor = rend.material.color;
            rend.material.color = telegraphColor.value;
        }

        timer = 0f;
    }

    protected override void OnUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= telegraphTime.value)
        {
            EndAction(true);
        }
    }

    protected override void OnStop()
    {
        if (rend != null)
        {
            rend.material.color = originalColor;
        }
    }
}
