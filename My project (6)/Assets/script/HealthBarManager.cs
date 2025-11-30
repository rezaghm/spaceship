using UnityEngine;
using UnityEngine.UIElements;

public class HealthBarManager : MonoBehaviour
{
    public static HealthBarManager Instance;

    private UIDocument document;
    private VisualElement healthBarPanel;
    private VisualElement[] healthSquares;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        document = GetComponent<UIDocument>();
        healthBarPanel = document.rootVisualElement.Q<VisualElement>("container3");

        // ۱۵ مربع
        healthSquares = new VisualElement[15];
        for (int i = 0; i < 15; i++)
        {
            healthSquares[i] = document.rootVisualElement.Q<VisualElement>("health" + (i + 1));
        }

        HideAll(); // مخفی کردن همه مربع‌ها در ابتدا
        healthBarPanel.style.display = DisplayStyle.None; // خود HealthBar مخفی
    }

    public void ShowBar()
    {
        healthBarPanel.style.display = DisplayStyle.Flex;
    }

    public void HideBar()
    {
        healthBarPanel.style.display = DisplayStyle.None;
    }

    public void ShowNextSquare(int currentHit)
    {
        if (currentHit >= 1 && currentHit <= 15)
        {
            healthSquares[currentHit - 1].style.display = DisplayStyle.Flex;
        }
    }

    private void HideAll()
    {
        foreach (var square in healthSquares)
        {
            if (square != null)
                square.style.display = DisplayStyle.None;
        }
    }
}
