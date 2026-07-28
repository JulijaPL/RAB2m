using UnityEngine;

public class player_movement : MonoBehaviour
{

    [SerializeField] float speed = 2f;
    public Rigidbody2D rb;
    private Vector2 movementDirection;
    

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        movementDirection = new Vector2(Input.GetAxisRaw("Horizontal"),0).normalized;
        

        
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = movementDirection * speed;
    }
}
