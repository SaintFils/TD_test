using Unity.Mathematics;
using UnityEngine;

namespace Code
{
    public class Tower : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private float fireRate;
        [SerializeField] private LayerMask enemyLayer;
        public Transform bulletPref;
        public int damage;

        private float _timeToFire;
        private Transform _gun, _enemy, _firePoint;

        private void Start()
        {
            _timeToFire = fireRate;
            _gun = transform.GetChild(0);
            _firePoint = _gun.GetChild(0);
        }

        private void Update()
        {
            if (_timeToFire > 0)
            {
                _timeToFire -= Time.deltaTime;
            }
            else if (_enemy)
            {
                Fire();
            }

            if (_enemy)
            {
                Vector3 lookAt = _enemy.position;
                lookAt.y = _gun.position.y;
                _gun.rotation = Quaternion.LookRotation((_gun.position - lookAt));

                if (Vector3.Distance(transform.position, _enemy.position) > radius)
                {
                    _enemy = null;
                }
            }
            else
            {
                Collider[] colliders = Physics.OverlapSphere(transform.position, radius, enemyLayer);
                if (colliders.Length > 0)
                {
                    _enemy = colliders[0].transform;
                }
            }
        }

        private void Fire()
        {
            Transform bullet = Instantiate(bulletPref, _firePoint.position, quaternion.identity);
            bullet.LookAt(_enemy);
            bullet.GetComponent<Bullet>().damage = damage;
            _timeToFire = fireRate;
        }
    }
}
