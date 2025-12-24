using UnityEngine;
using UnityEngine.UIElements;

public class BarManager : MonoBehaviour
{
    public UIDocument uiDocument; // ارجاع به UIDocument که UXML شما را نگه می‌دارد
    private VisualElement energyBar; // خود EnergyBar

    void Awake()
    {
        // پیدا کردن EnergyBar در UXML
        var root = uiDocument.rootVisualElement;
        energyBar = root.Q<VisualElement>("energyBar"); // اسم ID ای که در UXML گذاشتی
        energyBar.style.display = DisplayStyle.None; // ابتدا پنهان
    }

    // این تابع وقتی دکمه شروع بازی زده شد صدا زده می‌شود
    public void ShowEnergyBar()
    {
        if (energyBar != null)
        {
            energyBar.style.display = DisplayStyle.Flex; // نمایش EnergyBar
        }
    }
}

