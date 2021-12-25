using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Tank_DestroyState : FSMState
{
    [NonSerialized]
    public TankControl parent;
}
