using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _rb.velocity = new Vector2(horizontal, vertical) * walkSpeed;
    }
}
