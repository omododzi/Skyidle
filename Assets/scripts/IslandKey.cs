using UnityEngine;
using TMPro;

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

    void Start()
    {
        Tree = Random.Range(1, Distanse * 10);
        if (Distanse > 1)
        {
            Rock = Random.Range(1, Distanse * 10);
        }

        if (Distanse >2)
        {
            Grass = Random.Range(1, Distanse * 10);
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

    public void OpenNewIslands()
    {
        
    }
}
