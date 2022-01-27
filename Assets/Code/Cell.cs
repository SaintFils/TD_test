using UnityEngine;
using Random = UnityEngine.Random;


namespace Code
{
   public class Cell : MonoBehaviour
   {
      public Material mainMaterial;
      public Material canMaterial;
      public Material cantMaterial;

      public GameObject towerPref;
      public bool canBuild;

      private Renderer _rend;

      private void Start()
      {
         _rend = GetComponent<Renderer>();
      }

      private void OnMouseUp()
      {
         if (canBuild)
         {
            Instantiate(towerPref, transform.position, Quaternion.Euler(0, Random.Range(0, 360), 0));
            canBuild = false;
         }
      }

      private void OnMouseOver()
      {
         if (canBuild)
         {
            _rend.material = canMaterial;
         }
         else
         {
            _rend.material = cantMaterial;
         }
      }

      private void OnMouseExit()
      {
         _rend.material = mainMaterial;
      }
   }
}
