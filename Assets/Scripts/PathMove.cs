using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMove : MonoBehaviour {

    public List<PointMove> points=new List<PointMove>();
    // Use this for initialization
    public void AddNewPointMove(Vector3 pos)
    {
        GameObject go = new GameObject();
        go.name = "[point_" + points.Count.ToString() + "]";
        go.AddComponent<PointMove>();
        go.transform.position = pos;
        go.transform.SetParent(transform);
        points.Add(go.GetComponent<PointMove>());
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for(int i=1; i<points.Count;i++)
        {
            Gizmos.DrawLine(points[i - 1].transform.position, points[i].transform.position);
        }
        Gizmos.color = Color.green;
        for (int i = 0; i < points.Count; i++)
        {
            Gizmos.DrawWireSphere(points[i].transform.position, 0.2f);
        }
    }

}
