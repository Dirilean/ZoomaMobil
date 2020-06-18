using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteAlways]
public class BezierFollow : MonoBehaviour
{
    public Transform[] pointsTransforms;
    [Range(0,1)]
    public float t;
    Vector3[] pointsPosition;
    private void Update()
    {
        pointsPosition = pointsTransforms.Select(x=>x.position).ToArray();
        transform.position = Bezier.GetPoint(pointsPosition, t);
        transform.rotation =Quaternion.LookRotation(Bezier.GetDirection(pointsPosition, t));
    }
    private void OnDrawGizmos()
    {
        int smooth = 20;
        Vector3 curPoint = pointsPosition[0];

        for (int i = 0; i < smooth+1; i++)
        {
            float parametr = (float)i / smooth;
            Vector3 point = Bezier.GetPoint(pointsPosition, parametr);
            Gizmos.DrawLine(curPoint, point);
            curPoint = point;
        }
    }
}
