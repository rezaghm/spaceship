using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooter1 : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 25f;
    public float fireRate=0.5f;
    private float nextFireTime=0f;
    public int energyCount = 0;
    public TextMeshProUGUI energyText;


    void Update()
    {
        if (!GameManager.Instance.GameStarted)
            return;
        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            if(Time.time>= nextFireTime)
            {
                Shoot();
                nextFireTime=Time.time+fireRate;

            }

        }
    }

    void Shoot()
    {
        if(projectilePrefab == null || firePoint == null)
        {
            Debug.LogWarning("Shooter1: projectilePrefab یا firePoint تنظیم نشده.");
            return;
        }

        GameObject p = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Projectile projScript = p.GetComponent<Projectile>();

        if(projScript != null)
        {
            projScript.SetDirection(firePoint.up, projScript.speed);
            
        }
        else
        {
            Debug.LogWarning("Shooter1: روی prefab گلوله اسکریپت Projectile نیست یا حذف شده.");
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("energyCristal"))
        {
            energyCount++;
            if (energyText != null)
            {
                energyText.text = energyCount.ToString();
            }

            Destroy(other.gameObject);
        }
    }
}

