using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class IslandKey : MonoBehaviour
{
    public int Tree = 0;
    public int Rock = 0;
    public int Grass = 0;
    public int Distanse;
    public TMP_Text treewount;
    public TMP_Text rockwount;
    public TMP_Text grasswont;

    public GameObject rockimage;
    public GameObject grassimage;
    public GameObject treeimage;
    
    public List<GameObject> islands = new List<GameObject>();

    void Start()
    {
        Tree = Random.Range(10, Distanse * 100);
        if (Distanse > 1)
        {
            Rock = Random.Range(10, Distanse * 100);
        }

        if (Distanse >2)
        {
            Grass = Random.Range(10, Distanse * 100);
        }

        if (Rock >=1)
        {
            rockimage.SetActive(true);
        }

        if (Tree >=1)
        {
            treeimage.SetActive(true);
        }

        if (Grass>=1)
        {
            grassimage.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        if (treewount != null)
        {
             treewount.text = Tree + "";
        }

        if (rockwount != null)
        {
             rockwount.text = Rock + "";
        }

        if (grasswont != null)
        {
            grasswont.text = Grass + "";
        }
    }

    public void OpenThisIslands()
    {
        rockimage.SetActive(false);
        treeimage.SetActive(false);
        grassimage.SetActive(false);
        gameObject.GetComponent<BoxCollider>().enabled = false;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        if (islands != null)
        {
            for (int i = 0; i < islands.Count; i++)
            {
                islands[i].SetActive(true);
            }
        }
    }
}
