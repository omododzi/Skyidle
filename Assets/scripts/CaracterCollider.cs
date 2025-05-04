using Unity.VisualScripting;
using UnityEngine;

public class CaracterCollider : MonoBehaviour
{
   private CharacterController contrl;
   private GameObject Hitobj;

   void Start()
   {
      contrl = GetComponent<CharacterController>();
   }

   void OnControllerColliderHit(ControllerColliderHit hit)
   {
      if (hit.gameObject.CompareTag("Finish"))
      {
         Hitobj = hit.gameObject;
         Hitobj.GetComponent<BoxCollider>().enabled = false;
         Hitobj.transform.GetChild(0).gameObject.SetActive(true);
      }
   }
}
