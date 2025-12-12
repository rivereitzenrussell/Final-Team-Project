using UnityEngine;

public class BreakablePlatform : MonoBehaviour
{
    public float breakDelay = 1.0f;  // 玩家踩上后延迟几秒掉落
    private bool isSteppedOn = false;
    private Rigidbody2D rb;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        // 平台初始静止
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // 只有玩家踩上去才触发
        if (collision.gameObject.CompareTag("Player") && !isSteppedOn)
        {
            isSteppedOn = true;
            Invoke("BreakPlatform", breakDelay);
        }
    }

    void BreakPlatform()
    {
        // 变为可受重力影响掉落
        rb.bodyType = RigidbodyType2D.Dynamic;

        // 让玩家可以穿过
        col.enabled = false;

        // 可选：摧毁平台 5 秒后
        Destroy(gameObject, 5f);
    }
}
