using UnityEngine;

public class AutoJumpLeft : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 12f;         // 垂直跳跃力
    public float wallJumpForceX = 8f;     // 水平向左蹬墙力
    public float wallSlideSpeed = 2f;     // 贴墙下滑速度

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
        // 检测是否碰到墙（左或右都算）
        bool isTouchingWall = Physics2D.Raycast(wallCheck.position, Vector2.right, wallCheckDistance, wallLayer) ||
                              Physics2D.Raycast(wallCheck.position, Vector2.left, wallCheckDistance, wallLayer);

        // 如果碰到墙就自动蹬开向左
        if (isTouchingWall && rb.linearVelocity.y <= 0)
        {
            rb.linearVelocity = new Vector2(-wallJumpForceX, jumpForce); // 始终向左
        }

        // 可视化检测
        Debug.DrawRay(wallCheck.position, Vector3.right * wallCheckDistance, Color.red);
        Debug.DrawRay(wallCheck.position, Vector3.left * wallCheckDistance, Color.red);
    }
}
