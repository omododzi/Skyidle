using System;
using Unity.VisualScripting;
using UnityEngine;

public class CaracterCollider : MonoBehaviour
{
   private CharacterController contrl;
   private GameObject Hitobj;
   public int Trees;
   public int Rocks;
   public int Grass;
   public int damage = 50;
   private Treelcontroller tree;
   private Rock rock;
   private Grass grass;
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
         if (Trees >= island.Tree && Rocks >= island.Rock && Grass >= island.Grass)
         {
            Trees -= island.Tree;
            Rocks -= island.Rock;
            Grass -= island.Grass;
            island.OpenThisIslands();
         }
      }
   }

   void OnTriggerStay(Collider other)
   {
      
      if (other.gameObject.CompareTag("Tree"))
      {
         Hitobj = other.gameObject;
         tree = Hitobj.GetComponent<Treelcontroller>();
      }

      if (other.gameObject.CompareTag("Rock"))
      {
         Hitobj = other.gameObject;
         rock = Hitobj.GetComponent<Rock>();
      }

      if (other.gameObject.CompareTag("Grass"))
      {
         Hitobj = other.gameObject;
         grass = Hitobj.GetComponent<Grass>();
      }
   }

   private void Update()
   {
      if (tree != null)
      {
         if (Input.GetKeyDown(KeyCode.E) && tree.candamage  && !tree.reset)
         {
            Debug.Log(tree.hp);
            tree.hp -= damage;
            if (tree.hp <= 0)
            {
               Trees += tree.resourse;
            }
         }
      }
      

      if (rock != null)
      {
         if (Input.GetKeyDown(KeyCode.E) && rock.candamage  && !rock.reset)
         {
            rock.hp -= damage;
            if (rock.hp <= 0)
            {
               Rocks += rock.resourse;
            }
         }
      }
      
      if(grass != null)
      {
         if (Input.GetKeyDown(KeyCode.E) && grass.candamage &&  !grass.reset)
         {
            grass.hp -= damage;
            if (grass.hp <= 0)
            {
               Grass += grass.resourse;
            }
         }
      }
   }
}
