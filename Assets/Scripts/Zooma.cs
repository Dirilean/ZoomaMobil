using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Zooma : MonoBehaviour
{
    public float force=1f;
    public Renderer indicator;

    public Transform createPoint;
    public Transform shootPoint;

    Camera cam;
    Vector3 mousePoint;
    float angle = 0;

    GameObject curBall;
    BallItemData nextBall;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Start()
    {
        SetNextBall();
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
            mousePoint = ray.GetPoint(hitdist);
            transform.rotation = Quaternion.LookRotation(mousePoint - transform.position);
        }
    }
    void NewBall()
    {
        curBall = Instantiate(nextBall.ball);
        curBall.transform.SetPositionAndRotation(createPoint.position, createPoint.rotation);
    }
    //IEnumerator StartToShoot()
    //{
        
    //}
    void Shoot()
    {
        curBall.GetComponent<Rigidbody>().AddForce((mousePoint - transform.position).normalized*force, ForceMode.Impulse);
        SetNextBall();
    }
    void SetNextBall()
    {
        nextBall = BallData.instance.GetRandomBall();
        indicator.material.color = nextBall.color;
    }
}
