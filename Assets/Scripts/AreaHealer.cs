using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaHealer : MonoBehaviour
{
    public GameObject player; // Player objesi Inspector'dan atanmal�
    public HealtArrangement health;
    public float healCooldown = 1f; // �yile�tirme bekleme s�resi
    private float lastHealTime = 0f;

    private void Start()
    {
        // Player'�n i�indeki HealtArrangement bile�enini al
        if (player != null)
        {
            health = player.GetComponent<HealtArrangement>();
            if (health == null)
            {
                Debug.LogError("HealtArrangement bile�eni player �zerinde bulunamad�.");
            }
        }
        else
        {
            Debug.LogError("Player referans� atanmam��.");
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
