using System;
using UnityEngine;

public class Cameras : MonoBehaviour
{
    public Transform target;
    public float X;
    public float Y;
    public float Z;
    private Vector3 Newpos;

   
    private void FixedUpdate()
    {
        Newpos = new Vector3(target.position.x + X, target.position.y + Y, target.position.z + Z);
        gameObject.transform.position = Newpos;
    }
}