using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.BehaviourTrees;
using ParadoxNotion.Design;

[Category("GhostActions")]
public class FlashScareEffect : ActionTask<Transform>
{
    public Color flashColor = Color.red;
    public float flashDuration = 0.5f;

    private Renderer rend;
    private Color originalColor;
    private bool flashed = false;

    protected override void OnExecute()
    {
        rend = agent.GetComponentInChildren<Renderer>();

        if (rend == null)
        {
            Debug.LogWarning("No Renderer found on ghost!");
            EndAction(false);
            return;
        }

        originalColor = rend.material.color;
        rend.material.color = flashColor;
        flashed = true;

        StartCoroutine(RevertColor());
    }

    private IEnumerator RevertColor()
    {
        yield return new WaitForSeconds(flashDuration);

        if (flashed && rend != null)
        {
            rend.material.color = originalColor;
        }

        EndAction(true);
    }
}


