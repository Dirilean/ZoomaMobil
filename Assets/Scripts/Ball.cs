using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public void Throw(Vector3 dir)
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("!");
    }

}
