using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    private UIDocument document;
    private VisualElement gameOverPanel;
    private Button restartButton;
    private Button mainMenuButton;
    private Button exitButton;

    private void Awake()
    {
        // Singleton ساده
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        document = GetComponent<UIDocument>();
        gameOverPanel = document.rootVisualElement.Q<VisualElement>("container2");
        restartButton = document.rootVisualElement.Q<Button>("restart");
        // mainMenuButton = document.rootVisualElement.Q<Button>("home");
        exitButton = document.rootVisualElement.Q<Button>("exit");

        // ثبت callback برای دکمه‌ها
        restartButton.RegisterCallback<ClickEvent>(OnRestartClicked);
        // mainMenuButton.RegisterCallback<ClickEvent>(OnMainMenuClicked);
        exitButton.RegisterCallback<ClickEvent>(OnExitClicked);

        // در ابتدا مخفی باشد
        gameOverPanel.style.display = DisplayStyle.None;
    }

    public void ShowGameOver()
    {
        gameOverPanel.style.display = DisplayStyle.Flex;
        Time.timeScale = 0f; // توقف بازی هنگام Game Over
    }

    private void OnRestartClicked(ClickEvent evt)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ریست صحنه فعلی
    }

    // private void OnMainMenuClicked(ClickEvent evt)
    // {
    //     Time.timeScale = 1f;
    //     SceneManager.LoadScene("container"); // نام صحنه منوی اصلی
    // }

    private void OnExitClicked(ClickEvent evt)
    {
        Debug.Log("EXIT BUTTON CLICKED!");
#if UNITY_EDITOR
        // در Editor: خروج = خاموش شدن Play Mode (برای تست)
        EditorApplication.isPlaying = false;
#else
        // در Build واقعی: خروج از برنامه
        Application.Quit();
#endif
    }
}