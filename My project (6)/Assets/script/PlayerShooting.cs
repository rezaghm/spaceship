using UnityEngine;
using UnityEngine.InputSystem; // مهم: برای Input System جدید

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.2f;

    private float nextFireTime = 0f;

    void Update()
    {
        bool firePressed = false;

        // ماوس (اگر وجود داشته باشد)
        if (Mouse.current != null)
        {
            firePressed |= Mouse.current.leftButton.isPressed;
        }

        // کیبورد
        if (Keyboard.current != null)
        {
            firePressed |= Keyboard.current.spaceKey.isPressed;
        }

        // تاچ اسکرین / تاچ پد
        if (Touchscreen.current != null)
        {
            firePressed |= Touchscreen.current.primaryTouch.press.isPressed;
        }

        // اگر کلید شلیک فشار داده شده + زمان شلیک رسیده بود
        if (firePressed && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}

