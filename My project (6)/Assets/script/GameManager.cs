using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool GameStarted { get; private set; } = false;

    private void Awake()
    {
        // جلوگیری از ساخت دو GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        // اختیاری اگر می‌خوای بین صحنه‌ها بماند
        // DontDestroyOnLoad(gameObject);

        Time.timeScale = 0f;   // بازی قبل از Start متوقف است
        GameStarted = false;
    }

    public void StartGame()
    {
        GameStarted = true;
        Time.timeScale = 1f;   // بازی شروع می‌شود

        Debug.Log("Game Started!");
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
