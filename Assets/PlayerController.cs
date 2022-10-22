using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount;
    
    private Rigidbody2D rigidBody2D;

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
