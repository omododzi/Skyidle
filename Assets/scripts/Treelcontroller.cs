using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Treelcontroller : MonoBehaviour
{
    public int hp = 100;
    public int resourse = 10;
    public bool dead = false;
    private bool reset = false;
    
    private void FixedUpdate()
    {
        if (hp <= 0 && !reset)
        {
            Debug.Log("tree");
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            dead = true;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        reset = true;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<MeshRenderer>().enabled = true;
        hp = 100;
        reset = false;
        dead = false;
    }
}
