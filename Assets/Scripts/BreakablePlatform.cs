using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public float breakDelay = 1.0f; 
    private bool isSteppedOn = false;
    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player") && !isSteppedOn)
        {
            isSteppedOn = true;
            Invoke("BreakPlatform", breakDelay);
        }
    }

    void BreakPlatform()
    {
        
        rb.bodyType = RigidbodyType2D.Dynamic;

       
        col.enabled = false;

        
        Destroy(gameObject, 5f);
    }
}
