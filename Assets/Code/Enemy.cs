using UnityEngine;

namespace Code
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        public Transform[] wayPoints;
        public int currentHp;
        
        private Transform _currentPoint;
        private int _pointIndex;
        private Vector3 _direction;

        private void Start()
        {
            _pointIndex = 0;
            _currentPoint = wayPoints[_pointIndex];
        }

        public void SetHp(int newHp)
        {
            currentHp = newHp;
        }

        private void Update()
        {
            Rotate();
            Move();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Bullet"))
            {
                currentHp -= other.GetComponent<Bullet>().damage;
                Destroy(other.gameObject);

                if (currentHp < 0)
                {
                    Destroy(gameObject);
                }
            }
        }

        private void Move()
        {
            transform.position = Vector3.MoveTowards(transform.position, _currentPoint.position, speed*Time.deltaTime);
            if (transform.position == _currentPoint.position)
            {
                _pointIndex++;
                if (_pointIndex >= wayPoints.Length)
                {
                    Destroy(gameObject);
                }
                else
                {
                    _currentPoint = wayPoints[_pointIndex];
                }
            }
        }

        private void Rotate()
        {
            _direction = _currentPoint.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, _direction, Time.deltaTime * rotationSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
}
