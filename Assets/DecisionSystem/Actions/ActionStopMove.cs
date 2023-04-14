using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionStopMove : IAction
{
    [SerializeField]
    private S_ModePlayer moveScript;

    public override void Act()
    {
        if (moveScript != null)
        {
            moveScript.enabled = false;
        }
    }
}
