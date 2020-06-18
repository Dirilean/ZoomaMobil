using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Zooma : MonoBehaviour
{
    public float angle = 0;
    Camera cam;
    public GameObject prefabBullet;

    private void Awake()
    {
        cam = Camera.main;
    }
    void Update()
    {
        LookOnCursor();
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }
    void LookOnCursor()
    {     
        //заставляет персонажа следить за курсором мышки
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        float hitdist = 0;
        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetPoint = ray.GetPoint(hitdist);
            transform.rotation = Quaternion.LookRotation(targetPoint - transform.position);
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(prefabBullet);
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
