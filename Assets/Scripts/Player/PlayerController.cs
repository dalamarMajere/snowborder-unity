using Finishing;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float torqueAmount;
        [SerializeField] private float baseSpeed;
        [SerializeField] private float boostSpeed;
        [SerializeField] private FloatVariable surfaceSpeedVariable;
        
        private Rigidbody2D rigidBody2D;
        private SurfaceEffector2D surfaceEffector2D;

        private bool _isDisabled;

        private void Start()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
            GetComponent<GameEnd>().OnGameOver += (_) => _isDisabled = true;
        }

        private void Update()
        {
            if (_isDisabled)
            {
                return;
            }
            
            RotatePlayer();
            Boost();
        }

        private void Boost()
        {
            surfaceSpeedVariable.Value = Input.GetKey(KeyCode.UpArrow) ? boostSpeed : baseSpeed;
        }

        private void RotatePlayer()
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rigidBody2D.AddTorque(torqueAmount);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rigidBody2D.AddTorque(-torqueAmount);
            }
        }
    }
}
