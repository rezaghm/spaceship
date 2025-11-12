using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter1 : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (projectilePrefab == null || firePoint == null)
        {
            Debug.LogWarning("Shooter1: projectilePrefab یا firePoint تنظیم نشده.");
            return;
        }

        GameObject p = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projScript = p.GetComponent<Projectile>();
        if (projScript != null)
        {
            Vector2 fireDir = firePoint.up; // یا transform.up بسته به جهت‌گیری مثلث
            projScript.SetDirection(fireDir, projectileSpeed); // از اوورلود استفاده میکنیم
        }
        else
        {
            Debug.LogWarning("Shooter1: روی prefab گلوله اسکریپت Projectile نیست یا حذف شده.");
        }
    }
}
