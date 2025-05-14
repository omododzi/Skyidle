using UnityEngine;
using System.Collections;
public class Grass : MonoBehaviour
{
    public int hp = 20;
    public int resourse = 10;
    public bool candamage = false;
    public bool reset = false;
    public MeshRenderer rend;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            candamage = true;
        }
    }
    private void OnTriggerExit(Collider other)
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
            rend.enabled = false;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        reset = true;
        yield return new WaitForSeconds(15);
        rend.enabled = true;
        hp =20;
        reset = false;
    }
}
