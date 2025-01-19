using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHealer : MonoBehaviour
{
    public GameObject player; // Player objesi Inspector'dan atanmalý
    public HealtArrangement health;
    public float healCooldown = 1f; // Ýyileþtirme bekleme süresi
    private float lastHealTime = 0f;

    private void Start()
    {
        // Player'ýn içindeki HealtArrangement bileþenini al
        if (player != null)
        {
            health = player.GetComponent<HealtArrangement>();
            if (health == null)
            {
                Debug.LogError("HealtArrangement bileþeni player üzerinde bulunamadý.");
            }
        }
        else
        {
            Debug.LogError("Player referansý atanmamýþ.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        health.TakeHeal(10);
    }
    
    private void OnTriggerStay(Collider other)
    {
        if (Time.time >= lastHealTime + healCooldown && health.health < health.maxHealth)
        {
            health.TakeHeal(10);
            lastHealTime = Time.time;
        }
    }
}
