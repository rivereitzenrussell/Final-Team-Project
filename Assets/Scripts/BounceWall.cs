using UnityEngine;

public class BounceWall : MonoBehaviour
{
    [Header("Bounce Settings")]
    public float bounceForceX = 5f; // 水平反弹力
    public float bounceForceY = 10f; // 垂直反弹力

    [Header("Direction Settings")]
    public bool alwaysBounceLeft = false; // 是否始终向左反弹

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

            // 计算水平方向
            float horizontal = alwaysBounceLeft ? -Mathf.Abs(bounceForceX) : rb.linearVelocity.x > 0 ? -bounceForceX : bounceForceX;

            // 设置玩家速度，实现反弹
            rb.linearVelocity = new Vector2(horizontal, bounceForceY);
        }
    }
}
