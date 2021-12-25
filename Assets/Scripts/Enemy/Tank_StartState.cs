using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tank_StartState : FSMState
{
    [NonSerialized]
    public TankControl parent;
    private float timer;

    public override void OnEnter()
    {
        timer = 2;
        parent.trans.position = parent.path.points[0].transform.position;
        base.OnEnter();
    }

    public override void OnUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            parent.GotoState(parent.runState);
        }
        base.OnUpdate();
    }

}
