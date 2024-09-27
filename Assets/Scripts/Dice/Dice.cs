using UnityEngine;

namespace DiceController
{
    [RequireComponent(typeof(Rigidbody))]
    public class Dice : MonoBehaviour, IService
    {
        [SerializeField] private Vector3 offset;
        private SideTypes _currentType;
        private int _powerAttack;
        private Rigidbody m_rb;

        public Rigidbody RbDice { get { return m_rb; } 
        private set { m_rb = value; }
        }

        public SideTypes CurrentType
        {
            get { return _currentType; }
            private set { _currentType = value; }
        }

        public int PowerAttack
        {
            get { return _powerAttack; }
            private set { _powerAttack = value; }
        }

        public void Init()
        {
            m_rb = GetComponent<Rigidbody>();   
        }

        public void Rerol()
        {
            if (m_rb.velocity == Vector3.zero)
            {
                float dirX = Random.Range(0, 500);
                float dirY = Random.Range(0, 200);
                float dirZ = Random.Range(0, 500);

                transform.position = offset;
                transform.rotation = Quaternion.identity;

                m_rb.AddForce(transform.up * 200);
                m_rb.AddTorque(dirX, dirY, dirZ);
            }     
        }

        public void SetStatsDice(SideTypes type, int power)
        {
            _currentType = type;
            _powerAttack = power;
        }
    }
}