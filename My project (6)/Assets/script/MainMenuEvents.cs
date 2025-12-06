using UnityEngine;
using UnityEngine.UIElements;

public class mainMenuEvents : MonoBehaviour
{
    private UIDocument document;

    private VisualElement mainPanel;
    private VisualElement unlocksPanel;
    private VisualElement settingsPanel;

    private Button startButton;
    private Button unlocksButton;
    private Button settingsButton;

    private Button closeUnlocksButton;
    private Button closeSettingsButton;

    private void Awake()
    {
        document = GetComponent<UIDocument>();

        // گرفتن پنل‌ها
        mainPanel = document.rootVisualElement.Q<VisualElement>("container");
        unlocksPanel = document.rootVisualElement.Q<VisualElement>("unlocksPanel");
        settingsPanel = document.rootVisualElement.Q<VisualElement>("settingsPanel");

        // گرفتن دکمه‌ها
        startButton = document.rootVisualElement.Q<Button>("startGame");
        unlocksButton = document.rootVisualElement.Q<Button>("unlocks");
        settingsButton = document.rootVisualElement.Q<Button>("settings");

        closeUnlocksButton = document.rootVisualElement.Q<Button>("closeUnlocks");
        closeSettingsButton = document.rootVisualElement.Q<Button>("closeSettings");
        closeSettingsButton = document.rootVisualElement.Q<Button>("closeSettings");

        // ثبت رویدادها
        startButton.RegisterCallback<ClickEvent>(OnStartClicked);
        unlocksButton.RegisterCallback<ClickEvent>(OnUnlocksClicked);
        settingsButton.RegisterCallback<ClickEvent>(OnSettingsClicked);

        closeUnlocksButton.RegisterCallback<ClickEvent>(OnCloseUnlocks);
        closeSettingsButton.RegisterCallback<ClickEvent>(OnCloseSettings);

        // بازی در ابتدا متوقف باشد
        Time.timeScale = 0;

        // مخفی بودن دو پنل کوچک
        unlocksPanel.style.display = DisplayStyle.None;
        settingsPanel.style.display = DisplayStyle.None;
    }

    private void OnStartClicked(ClickEvent evt)
    {
        Debug.Log("Start pressed");
        GameManager.Instance.StartGame();
        mainPanel.style.display = DisplayStyle.None;
        Time.timeScale = 1; // بازی شروع می‌شود

        HealthBarManager.Instance.ShowBar();
    }

    private void OnUnlocksClicked(ClickEvent evt)
    {
        unlocksPanel.style.display = DisplayStyle.Flex;
    }

    private void OnSettingsClicked(ClickEvent evt)
    {
        settingsPanel.style.display = DisplayStyle.Flex;
    }

    private void OnCloseUnlocks(ClickEvent evt)
    {
        unlocksPanel.style.display = DisplayStyle.None;
    }

    private void OnCloseSettings(ClickEvent evt)
    {
        settingsPanel.style.display = DisplayStyle.None;
    }
}
