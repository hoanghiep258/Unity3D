using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionSceneConfig : MonoBehaviour {
    public static MissionSceneConfig Instance;

    [SerializeField]
    public List<PathMove> paths=new List<PathMove>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Use this for initialization
    public void AddNewPathMove()
    {
        GameObject go = new GameObject();
        go.name = "[path_" + paths.Count.ToString() + "]";
        go.AddComponent<PathMove>();
        go.transform.SetParent(transform);
        paths.Add(go.GetComponent<PathMove>());
    }    
}
