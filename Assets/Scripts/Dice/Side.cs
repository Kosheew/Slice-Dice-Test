using UnityEngine;

namespace DiceController
{
    public class Side : MonoBehaviour
    {
        private Dice _dice;
        [SerializeField] private SideTypes _sideType;
        [SerializeField] private int _sidePower;

        private void Awake()
        {
            _dice = GetComponentInParent<Dice>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Platform"))
            {
                _dice.SetStatsDice(_sideType, _sidePower);
            }
        }
    }
}
