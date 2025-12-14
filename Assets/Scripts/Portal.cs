using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportTarget;  // 玩家要传送到的位置

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 玩家瞬移到目标位置
            collision.transform.position = teleportTarget.position;

            // 可选：播放传送特效或声音
            // SoundManager.Instance.PlaySFX("TELEPORT");
        }
    }
}
