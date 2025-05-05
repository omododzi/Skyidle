using UnityEngine;

public class IslandKey : MonoBehaviour
{
    public int Tree = 0;
    public int Rock = 0;
    public int Distanse;

    void Start()
    {
        Tree = Random.Range(1, Distanse * 10);
        if (Distanse != 1)
        {
            Rock = Random.Range(1, Distanse * 10);
        }
    }
}
