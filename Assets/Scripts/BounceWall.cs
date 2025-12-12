using UnityEngine;

public class BounceWall : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceForceX = 5f; 
    public float bounceForceY = 10f; 

    [Header("Direction Settings")]
    public bool alwaysBounceLeft = false; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            float horizontal = alwaysBounceLeft ? -Mathf.Abs(bounceForceX) : rb.linearVelocity.x > 0 ? -bounceForceX : bounceForceX;

           
            rb.linearVelocity = new Vector2(horizontal, bounceForceY);
        }
    }
}
