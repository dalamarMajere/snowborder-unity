using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float torqueAmount;
        [SerializeField] private float baseSpeed;
        [SerializeField] private float boostSpeed;
    
        private Rigidbody2D rigidBody2D;
        private SurfaceEffector2D surfaceEffector2D;

        private void Start()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
            surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        }

        private void Update()
        {
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
