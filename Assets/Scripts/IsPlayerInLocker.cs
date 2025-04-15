using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

[Category("Krasue")]
public class IsPlayerInLocker : ConditionTask
{
    private PlayerController player;

    protected override string info => "Player is in locker";

    protected override bool OnCheck()
    {
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.GetComponent<PlayerController>();
        }

        return player != null && player.IsHiding() && player.GetHideType() == "Locker";
    }
}
