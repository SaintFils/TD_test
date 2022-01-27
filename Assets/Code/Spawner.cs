using UnityEngine;

namespace Code
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private Enemy enemyPref;
        [SerializeField] private float spawnTime;
        [SerializeField] private Transform[] wayPoints;
        public int EnemyHp;

        private float _timer;

        private void Start()
        {
            _timer = spawnTime;
        }

        private void Update()
        {
            _timer -= Time.deltaTime;
            Spawn();
        }

        private void Spawn()
        {
            if (_timer <= 0)
            {
                Enemy enemy = Instantiate(enemyPref, transform.position, Quaternion.identity);
                enemy.wayPoints = wayPoints;
                enemy.SetHp(EnemyHp);
                _timer = spawnTime;
            }
        }
    }
}
