using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tank_RunState : FSMState
{
    [NonSerialized]
    public TankControl parent;
    private int indexPoint = -1;
    private Vector3 aimPoint;
    private Transform trans;
    List<PointMove> lsPointMoves = new List<PointMove>();

    public override void OnEnter()
    {
        indexPoint = 1;
        trans = parent.trans;
        lsPointMoves = parent.path.points;
        aimPoint = lsPointMoves[indexPoint].transform.position;
        base.OnEnter();
    }

    private void RotateToAim()
    {
        Vector3 dir = aimPoint - trans.position;
        dir.Normalize();
        trans.localRotation = Quaternion.Slerp(trans.localRotation,
            Quaternion.LookRotation(dir), Time.deltaTime * 50f);
    }

    public override void OnUpdate()
    {
        RotateToAim();
        trans.Translate(Vector3.forward * Time.deltaTime * 5);
        
        CheckNextPoint();
        base.OnUpdate();
    }

    private void CheckNextPoint()
    {
        float distance = Vector3.Distance(trans.position, aimPoint);
        if (distance <= 0.5f)
        {
            indexPoint++;
        }
        else
        {
            return;
        }

        if (indexPoint >= lsPointMoves.Count)
        {
            parent.GotoState(parent.boomState);
        }
        else
        {
            aimPoint = lsPointMoves[indexPoint].transform.position;
        }

    }
}
