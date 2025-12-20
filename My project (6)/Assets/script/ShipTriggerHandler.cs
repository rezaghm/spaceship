

using TMPro;
using UnityEngine;

public class ShipTriggerHandler : MonoBehaviour
{
    public int hitCount = 0;
    
    public int maxHits = 15;
    
    private bool isGameOver = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            hitCount++;
            HealthBarManager.Instance.ShowNextSquare(hitCount);

            if (hitCount >= maxHits && !isGameOver)
            {
                isGameOver = true;
                EndGame();
            }
        }
        

    }

    void EndGame()
    {
        // ساخت شیء نامرئی با تگ Player قبل از غیرفعال شدن سفینه
        GameObject invisiblePlayer = new GameObject("InvisiblePlayer");
        invisiblePlayer.tag = "Player";
        // اگر لازم است Collider یا Rigidbody اضافه کنید، اینجا می‌توان اضافه کرد
        invisiblePlayer.transform.position = transform.position; // کاملاً نامرئی و غیرفعال

        // غیرفعال کردن کل سفینه و فرزندانش
        gameObject.SetActive(false);

        // غیرفعال کردن حرکت و فیزیک همه دشمن‌ها
        // EnemyAi[] enemies = Object.FindObjectsByType<EnemyAi>(FindObjectsSortMode.None);
        // foreach (EnemyAi enemy in enemies)
        // {
        //     enemy.enabled = false;

        //     Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();
        //     if (rb != null) rb.simulated = false;

        //     Collider2D col = enemy.GetComponent<Collider2D>();
        //     if (col != null) col.enabled = false;
        // }

        // چاپ پیام گیم اور
        Debug.Log("Game Over!");
        GameOverManager.Instance.ShowGameOver();
    }
}

