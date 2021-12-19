using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathMove))]
public class PathMoveEditor : Editor
{
    public static SceneView GetSceneView()
    {
        SceneView view = SceneView.lastActiveSceneView;
        if (view == null)
            view = EditorWindow.GetWindow<SceneView>();

        return view;
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("GetFocus"))
        {
            GetSceneView().Focus();
        }
       
    }
    private void OnSceneGUI()
    {    
        if (Event.current.type != EventType.KeyDown)
         return;
        PathMove myScript = (PathMove)target;
        if (Event.current.keyCode == KeyCode.Space)
        {
            //cast a ray against mouse position
            Ray worldRay = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            
            RaycastHit hitInfo;
            if(Physics.Raycast(worldRay, out hitInfo))
                    {
                Event.current.Use();

                Debug.Log(hitInfo.point);
                myScript.AddNewPointMove(hitInfo.point);
            }
        }
    }    
}