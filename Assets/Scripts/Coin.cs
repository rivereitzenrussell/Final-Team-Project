using UnityEngine;
using TMPro;
using System.Reflection;

public class Coin : MonoBehaviour
{
    public AudioClip coinClip;
    private TextMeshProUGUI coinText;

    private void Start()
    {
       coinText = GameObject.FindWithTag("CoinText").GetComponent<TextMeshProUGUI>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController player = collision.gameObject.GetComponent<PlayerController>();
            player.coins += 1;
            Destroy(gameObject);
            coinText.text = player.coins.ToString();
            SoundManager.Instance.PlaySFX("COIN", 0.4f);
        }
    }
}
