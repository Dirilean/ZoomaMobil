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
    public float pausetime;

    Camera cam;
    Vector3 mousePoint;
    float accurancy = 0.2f;

    GameObject curBall;
    BallItemData nextBall;

    bool pause = true;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Start()
    {
        nextBall = BallData.instance.GetRandomBall();
        SetNextBall();
    }
    void Update()
    {
        LookOnCursor();
        if (!pause && Input.GetMouseButtonDown(0))
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
        curBall = Instantiate(nextBall.ball,transform);
        curBall.transform.SetPositionAndRotation(createPoint.position, createPoint.rotation);
        StartCoroutine(StartToShoot());
    }
    IEnumerator StartToShoot()
    {
        Rigidbody rb = curBall.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        pause = true;
        while(Vector3.Distance(curBall.transform.position, shootPoint.transform.position)>accurancy)
        {
            curBall.transform.position = Vector3.Lerp(curBall.transform.position, shootPoint.transform.position, Time.deltaTime * pausetime);
            yield return null;
        }
        curBall.transform.position = shootPoint.transform.position;
        rb.isKinematic = false;
        pause = false;
    }
    void Shoot()
    {
        curBall.transform.parent = null;
        curBall.GetComponent<Rigidbody>().AddForce((mousePoint - transform.position).normalized*force, ForceMode.Impulse);
        SetNextBall();
    }
    void SetNextBall()
    {
        NewBall();
        nextBall = BallData.instance.GetRandomBall();
        indicator.material.color = nextBall.color;
    }
}
