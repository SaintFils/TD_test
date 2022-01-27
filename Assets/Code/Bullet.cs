using UnityEngine;

namespace Code
{
   public class Bullet : MonoBehaviour
   {
      public float speed;
      public int damage;

      private void Start()
      {
         Destroy(gameObject, 2);
      }

      private void Update()
      {
         transform.Translate(Vector3.forward * (speed * Time.deltaTime));
      }
   }
}
