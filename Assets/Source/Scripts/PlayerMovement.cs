using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 6f;
    private Rigidbody2D _rb;
    
    [SerializeField] private GameObject playerModel;
    [SerializeField] private GameObject gun;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        _rb.velocity = new Vector2(horizontal, vertical) * walkSpeed;

        if (_rb.velocity.x < 0)
        {
            playerModel.transform.localScale = new Vector3(-1f, 1f, 1f);
            //gun.transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (_rb.velocity.x > 0)
        {
            playerModel.transform.localScale = new Vector3(1f, 1f, 1f);
            //gun.transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
