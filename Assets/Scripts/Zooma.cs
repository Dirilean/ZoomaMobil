using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zooma : MonoBehaviour
{
    // Start is called before the first frame update

    public float angle = 0;


    // public Camera camera;
    // Update is called once per frame
    void Update()
    {
        LookOnCursor();
    }
    void LookOnCursor()
    {     
        //заставляет персонажа следить за курсором мышки
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            transform.rotation = Quaternion.LookRotation(targetPoint - transform.position);
        }
    }
}
