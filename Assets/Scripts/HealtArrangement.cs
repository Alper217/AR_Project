using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtArrangement : MonoBehaviour
{
    public Image healthBar; 
    public float health = 100f;
    public float maxHealth = 100f;
    public float healCooldown = 1f; // �yile�tirme bekleme s�resi
    private float lastHealTime = 0f;
    public bool isTakingDamage = false; // Oyuncunun hasar al�p almad���n� takip etmek i�in
    public void TakeDamage(float damage)
    {
        isTakingDamage = true; // Hasar al�nd� olarak i�aretle
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        healthBar.fillAmount = health / maxHealth;

        if (health <= 0f)
        {
            Die();
        }

        StartCoroutine(ResetTakingDamage()); // Belirli bir s�re sonra hasar durumunu s�f�rla
    }
    private IEnumerator ResetTakingDamage()
    {
        yield return new WaitForSeconds(0.5f); // �rne�in 0.5 saniye bekle
        isTakingDamage = false; // Hasar alma durumu sona erdi
    }

    public void TakeHeal(float heal)
    {
        if (!isTakingDamage) // Sadece hasar al�nm�yorsa iyile�tir
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
