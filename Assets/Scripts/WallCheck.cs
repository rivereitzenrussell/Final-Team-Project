using UnityEngine;

public class AutoJumpLeft : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 12f;         
    public float wallJumpForceX = 8f;     
    public float wallSlideSpeed = 2f;     

    [Header("Wall Detection")]
    public Transform wallCheck;
    public float wallCheckDistance = 0.5f;
    public LayerMask wallLayer;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        bool isTouchingWall = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, wallLayer) ||
                              Physics2D.Raycast(wallCheck.position, Vector2.left, wallCheckDistance, wallLayer);

       
        if (isTouchingWall && rb.linearVelocity.y <= 0)
        {
            rb.linearVelocity = new Vector2(-wallJumpForceX, jumpForce); 
        }

       
        Debug.DrawRay(wallCheck.position, Vector3.right * wallCheckDistance, Color.red);
        Debug.DrawRay(wallCheck.position, Vector3.left * wallCheckDistance, Color.red);
    }
}
