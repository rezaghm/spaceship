using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Settings")]
    public float speed =25f;        // سرعت قابل تنظیم از Inspector
    public float lifeTime = 5f;      // زمان نابودی خودکار

    private Vector2 direction = Vector2.zero;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // نابودی خودکار پس از مدت مشخص
        Destroy(gameObject, lifeTime);

        // اگر جهت تعیین نشده، از جهت محلی استفاده کن
        if (direction == Vector2.zero)
            direction = transform.up;

        ApplyVelocity();
    }

    // تعیین جهت تیر
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        ApplyVelocity();
    }

    // تعیین جهت + سرعت سفارشی (اختیاری)
    public void SetDirection(Vector2 dir, float customSpeed)
    {
        direction = dir.normalized;
        speed = customSpeed;
        ApplyVelocity();
    }

    // اعمال سرعت واقعی به Rigidbody2D
    private void ApplyVelocity()
    {
        if (rb != null)
        {
            rb.linearVelocity = direction * speed;
        }
    }

    // برخورد با دشمن
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);   // حذف دشمن
            Destroy(gameObject);         // حذف گلوله
        }
    }

    void Update()
    {
        // اگر Rigidbody2D نداشتیم، دست‌ساز حرکتش بده
        if (rb == null)
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }
}

