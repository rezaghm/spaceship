using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 5f;
    private Vector2 direction = Vector2.right;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
        // اگر هنوز جهت‌ دهی نشده بود، از جهت محلی استفاده کن
        if (direction == Vector2.zero) direction = transform.up;
        // اگر Rigidbody2D موجود باشه از velocity استفاده کن
        if (rb != null)
            rb.linearVelocity = direction.normalized * speed;
    }

    // فراخوانی از Shooterها: فقط جهت
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        if (rb != null)
            rb.linearVelocity = direction * speed;
    }

    // اوورلود: جهت + سرعت مختص به این شوت
    public void SetDirection(Vector2 dir, float customSpeed)
    {
        direction = dir.normalized;
        if (rb != null)
            rb.linearVelocity = direction * customSpeed;
        else
            speed = customSpeed;
    }

    void Update()
    {
        // در صورتی که Rigidbody نداریم، با Translate حرکت کن
        if (rb == null)
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
