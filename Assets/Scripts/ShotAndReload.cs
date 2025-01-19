using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI; // UI Text kullanýmý için gerekli

public class ShotAndReload : MonoBehaviour
{
    
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    public float projectileLifetime = 5f;
    public TextMeshProUGUI ammoText;
    public int ammoCount = 90;
    void Start()
    {
        UpdateAmmoText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammoCount > 0)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject spawnedProjectile = Instantiate(projectilePrefab, transform.position, transform.rotation * Quaternion.Euler(90f, 0, 0));
        Rigidbody rb = spawnedProjectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * projectileSpeed;
        }
        Destroy(spawnedProjectile, projectileLifetime);
        ammoCount--;
        UpdateAmmoText();
    }
    public void UpdateAmmoText()
    {
        if (ammoText != null)
        {
            ammoText.text = ammoCount.ToString();
        }
        else
        {
            Debug.LogWarning("Ammo Text is not assigned in the Inspector.");
        }
    }
}
