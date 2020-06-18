using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Bezier
{
    //public static Vector3 GetPoint(Vector3[] points,float t)
    //{
    //    if (points.Length != 4)
    //    {
    //        Debug.LogError("!");
    //        return Vector3.zero;
    //    }

    //    //первая итерация
    //    Vector3[] _points = new Vector3[3];
    //    _points[0] = Vector3.Lerp(points[0], points[1], t);
    //    _points[1] = Vector3.Lerp(points[1], points[2], t);
    //    _points[2] = Vector3.Lerp(points[2], points[3], t);

    //    //Вторая итерация
    //    points = new Vector3[2];
    //    points[0] = Vector3.Lerp(_points[0], _points[1], t);
    //    points[1] = Vector3.Lerp(_points[1], _points[2], t);

    //    //третья итерация - результат
    //    return Vector3.Lerp(points[0], points[1],t);
    //}

    public static Vector3 GetPoint(Vector3[] points, float t)
    {
        if (points.Length != 4)
        {
            Debug.LogError("points lenght not equal 4");
            return Vector3.zero;
        }

        //формула безье для 4х точек: P = ((1−t)^3)*P0 + 3((1−t)^2)t*P1 + 3(1−t)*(t^2)*P2+ (t^3)*P3
        return 
            Mathf.Pow((1 - t), 3) * points[0] +
            3 * Mathf.Pow((1 - t), 2) * t * points[1] +
            3 * (1 - t) * Mathf.Pow(t, 2) * points[2] +
            Mathf.Pow(t, 3) * points[3];
    }

    public static Vector3 GetDirection(Vector3[] points, float t)
    {
        if (points.Length != 4)
        {
            Debug.LogError("points lenght not equal 4");
            return Vector3.zero;
        }
        //Производная от формулы безье
        //3*((1-t)^2)*(p1-p0)+6*(1-t)*t*(p2-p1)+3*(t^2)*(p3-p2)
        return
            3 * (1 - t) * (1 - t) * (points[1] - points[0]) +
            6 * (1 - t) * t * (points[2] - points[1]) +
            3 * t * t * (points[3] - points[2]);
    }
}
