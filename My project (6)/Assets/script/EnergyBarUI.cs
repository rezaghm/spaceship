using UnityEngine;
using UnityEngine.UIElements;

public class EnergyBarUI : MonoBehaviour
{
    [Header("UI Document")]
    public UIDocument uiDocument; // حتما در Inspector وصل کن

    [Header("Energy Settings")]
    public int maxEnergy = 10;      // حداکثر انرژی
    public int energyCount = 0;     // مقدار فعلی انرژی
    public float fillAnimationSpeed = 5f; // سرعت پر شدن نوار

    [Header("UI Elements")]
    public string energyBarName = "energyFill"; // اسم VisualElement در UI Builder

    private VisualElement bar;
    private float targetWidth=0;
    private const float fullWidth = 200f; // عرض کامل نوار در پیکسل

    void Start()
    {
        if (uiDocument == null)
        {
            Debug.LogError("UIDocument is not assigned in Inspector!");
            return;
        }

        // گرفتن نوار انرژی
        bar = uiDocument.rootVisualElement.Q<VisualElement>(energyBarName);
        if (bar == null)
        {
            Debug.LogError($"VisualElement '{energyBarName}' not found! Check the name in UI Builder.");
            return;
        }

        // مقدار اولیه نوار
        bar.style.width = 0;
        targetWidth = 0;
    }

    void Update()
    {
        if (bar != null)
        {
            // انیمیشن آرام پر شدن نوار
            float currentWidth = bar.resolvedStyle.width;
            currentWidth = Mathf.Lerp(currentWidth, targetWidth, Time.deltaTime * fillAnimationSpeed);
            bar.style.width = new StyleLength(new Length(currentWidth, LengthUnit.Pixel));
        }
    }

    /// <summary>
    /// افزایش انرژی
    /// </summary>
    /// <param name="amount">مقدار اضافه شده</param>
    public void AddEnergy(int amount)
    {
        energyCount += amount;
        if (energyCount > maxEnergy) energyCount = maxEnergy;
        if (energyCount < 0) energyCount = 0;

        // تعیین عرض هدف نوار
        targetWidth = (float)energyCount / maxEnergy * fullWidth;

        Debug.Log($"EnergyCount: {energyCount}, TargetWidth: {targetWidth}");
    }

    /// <summary>
    /// کاهش انرژی
    /// </summary>
    /// <param name="amount">مقدار کاهش</param>
    public void RemoveEnergy(int amount)
    {
        AddEnergy(-amount);
    }
}









