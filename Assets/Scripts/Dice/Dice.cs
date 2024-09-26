using UnityEngine;

namespace DiceController
{
    [RequireComponent(typeof(Rigidbody))]
    public class Dice : MonoBehaviour
    {
        private SideTypes _currentType;
        private int _powerAttack;
        private Rigidbody m_rb;

        private void Awake()
        {
            m_rb = GetComponent<Rigidbody>();
        }

        public void Rerol()
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);

            transform.position = new Vector3(0, 1, 0);
            transform.rotation = Quaternion.identity;
                 
            m_rb.AddForce(transform.up * 500);
            m_rb.AddTorque(dirX, dirY, dirZ);    
        }

        public void Attack()
        {
            if (m_rb.velocity == Vector3.zero)
            {
                Debug.Log(_powerAttack);
                Debug.Log(_currentType);
            }
        }

        public void SetStatsDice(SideTypes type, int power)
        {
            _currentType = type;
            _powerAttack = power;
        }
    }
}