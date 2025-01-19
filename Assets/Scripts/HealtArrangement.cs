using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtArrangement : MonoBehaviour
{
    public Image healthBar; 
    public float health = 100f;
    public float maxHealth = 100f;
    public float healCooldown = 1f; // Ýyileþtirme bekleme süresi
    private float lastHealTime = 0f;
    public bool isTakingDamage = false; // Oyuncunun hasar alýp almadýðýný takip etmek için
    public void TakeDamage(float damage)
    {
        isTakingDamage = true; // Hasar alýndý olarak iþaretle
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0f)
        {
            Die();
        }

        StartCoroutine(ResetTakingDamage()); // Belirli bir süre sonra hasar durumunu sýfýrla
    }
    private IEnumerator ResetTakingDamage()
    {
        yield return new WaitForSeconds(0.5f); // Örneðin 0.5 saniye bekle
        isTakingDamage = false; // Hasar alma durumu sona erdi
    }

    public void TakeHeal(float heal)
    {
        if (!isTakingDamage) // Sadece hasar alýnmýyorsa iyileþtir
        {
            health += heal;
            health = Mathf.Clamp(health, 0, maxHealth);
            healthBar.fillAmount = health / maxHealth;
        }
    }
    void Die()
    {
        Time.timeScale = 0f; 
        Debug.Log("Player is dead!"); 
    }
}
