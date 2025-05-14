using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Rock : MonoBehaviour
{
    public int hp = 300;
    public int resourse = 10;
    public bool candamage = false;
    public bool reset = false;
    public MeshRenderer rend;
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
            Debug.Log("rock");
            rend.enabled = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        reset = true;
        yield return new WaitForSeconds(5);
        rend.enabled = true;
        hp = 300;
        reset = false;
    }
}
