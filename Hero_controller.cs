using UnityEngine;

public class HeroController : MonoBehaviour
{
    public GameManager gameManager;
    public FixedJoystick Joystick;
    Rigidbody2D rb;
    Vector2 move;
    public float moveSpeed;
    private Vector2 lastMove;
    private bool ismoving = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;
        
        if (move != Vector2.zero)
        {
            lastMove = move;
            ismoving = true;
        }
        else
        {
            ismoving = false;
        }
        
        float hAxis = lastMove.x;
        float vAxis = lastMove.y;
        float zAxis = Mathf.Atan2(hAxis, vAxis) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, -zAxis);
    }

    private void FixedUpdate()
    {
        if (ismoving)
        {
            rb.MovePosition(rb.position + lastMove * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            gameManager.LevelFail();
            Destroy(gameObject);
        }
    }
}
