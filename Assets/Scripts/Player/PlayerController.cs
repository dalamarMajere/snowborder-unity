using UnityEngine;
using Variables;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float torqueAmount;
        [SerializeField] private float baseSpeed;
        [SerializeField] private float boostSpeed;

        [SerializeField] private BooleanVariable isGameOver;
    
        private Rigidbody2D rigidBody2D;
        private SurfaceEffector2D surfaceEffector2D;

        private void Start()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
            surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
            isGameOver.Value = false;
        }

        private void Update()
        {
            if (isGameOver.Value)
            {
                return;
            }
            
            RotatePlayer();
            Boost();
        }

        private void Boost()
        {
            surfaceEffector2D.speed = Input.GetKey(KeyCode.UpArrow) ? boostSpeed : baseSpeed;
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
