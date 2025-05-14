using UnityEngine;
using TMPro;
public class Loot : MonoBehaviour
{
   public TMP_Text treescore;
   public TMP_Text grasscore;
   public TMP_Text rockscore;
   private GameObject player;
   private CaracterCollider scoreplayer;

   void Start()
   {
      player = GameObject.FindGameObjectWithTag("Player");
      scoreplayer = player.GetComponent<CaracterCollider>();
   }

   void FixedUpdate()
   {
      treescore.text = scoreplayer.Trees.ToString();
      grasscore.text = scoreplayer.Grass.ToString();
      rockscore.text = scoreplayer.Rocks.ToString();
   }
}
