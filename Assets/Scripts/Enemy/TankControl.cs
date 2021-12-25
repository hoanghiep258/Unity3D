using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControl : FSMSystem
{
    public Transform trans;
    public PathMove path;

    public Tank_BoomState boomState;
    public Tank_DestroyState destroyState;
    public Tank_RunState runState;
    public Tank_StartState startState;


    public override void OnSystemStart()
    {
        base.OnSystemStart();
        trans = transform;
        path = MissionSceneConfig.Instance.paths[0];

        startState.parent = this;
        AddState(startState);

        boomState.parent = this;
        AddState(boomState);

        runState.parent = this;
        AddState(runState);

        destroyState.parent = this;
        AddState(destroyState);
    }
}
