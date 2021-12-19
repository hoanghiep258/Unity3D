using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MissionSceneConfig))]
public class MissionSceneConfigEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        MissionSceneConfig myScript = (MissionSceneConfig)target;
        if (GUILayout.Button("Add Path"))
        {
            myScript.AddNewPathMove();
        }
    }
    private void OnSceneGUI()
    {

    }


}
