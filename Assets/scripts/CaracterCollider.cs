using Unity.VisualScripting;
using UnityEngine;

public class CaracterCollider : MonoBehaviour
{
   private CharacterController contrl;
   private GameObject Hitobj;
   public int Trees;
   public int Rocks;
   public int damage = 50;
   void Start()
   {
      contrl = GetComponent<CharacterController>();
   }
   void OnControllerColliderHit(ControllerColliderHit hit)
   {
      if (hit.gameObject.CompareTag("Finish"))
      {
         Hitobj = hit.gameObject;
         var island = Hitobj.GetComponent<IslandKey>();
         if (Trees >= island.Tree && Rocks >= island.Rock)
         {
            Hitobj.GetComponent<BoxCollider>().enabled = false;
            Hitobj.transform.GetChild(0).gameObject.SetActive(true);
            Trees -= island.Tree;
            Rocks -= island.Rock;
         }
      }

    
   }

   void OnTriggerStay(Collider other)
   {
      if (other.gameObject.CompareTag("Tree"))
      {
         Hitobj = other.gameObject;
         var tree = Hitobj.GetComponent<Treelcontroller>();
         if (Input.GetKeyDown(KeyCode.E))
         {
            Debug.Log(tree.hp);
            tree.hp -= damage;
            if (tree.hp <= 0)
            {
               Trees += tree.resourse;
            }
         }
      }
   }
}
