using UnityEngine;

public class MovingPlatform : MonoBehaviour


{
    public float distance = 3f;   // how far to move left/right from its starting point
    public float speed = 2f;      // how fast the platform moves

    private Vector3 startPos; // store the starting position of the platform
    private int direction = 1; // direction of movement: 1 = right, -1 = left.

    void Start()
    {
        // remember the starting position when the game begins
        startPos = transform.position;
    }

    void Update()
    {
        // move platform left/right each frame
        transform.Translate(Vector3.right * direction * speed * Time.deltaTime);

        // if platform has moves a set distance from start
        if (Mathf.Abs(transform.position.x - startPos.x) >= distance)
        {
            // reverse direction
            direction *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if player lands on the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // attach player to platform so they move together
            collision.transform.SetParent(transform);
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // if the player leaves the platform
        if (collision.gameObject.CompareTag("Player"))
        {
            // detach player so they move independantly again
            collision.transform.SetParent(null);
        }
    }
}