using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Treelcontroller : MonoBehaviour
{
    public int hp = 100;
    public int resourse = 10;
    public bool candamage = false;
    public bool reset = false;
    public MeshRenderer mesh;

    void Start()
    {
        if (mesh == null)
        {
            mesh = GetComponent<MeshRenderer>();
        }
       
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            candamage = true;
        }
    }
 private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            candamage = false;
        }
    }

    private void FixedUpdate()
    {
        if (hp <= 0 && !reset)
        {
            Debug.Log("tree");
            mesh.enabled = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        reset = true;
        yield return new WaitForSeconds(2);
        mesh.enabled = true;
        hp = 100;
        reset = false;
    }
}
