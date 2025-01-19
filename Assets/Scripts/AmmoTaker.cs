using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTaker : MonoBehaviour
{
    public GameObject player;
    private ShotAndReload playerAmmo;

    public int ammoIncreaseAmount = 1; // Her art��ta eklenecek mermi miktar�
    public float ammoIncreaseDelay = 1f; // Mermi art�� aral��� (saniye)
    private float nextAmmoTime = 0f; // Bir sonraki art�rma zaman�

    void Start()
    {
        if (player != null)
        {
            playerAmmo = player.GetComponent<ShotAndReload>();
            if (playerAmmo == null)
            {
                Debug.LogError("ShotAndReload scripti player �zerinde bulunamad�.");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // E�er oyuncu alanda ve belirli s�re ge�mi�se mermi ekle
        if (playerAmmo != null && Time.time >= nextAmmoTime)
        {
            playerAmmo.ammoCount += ammoIncreaseAmount; // Belirtilen miktarda mermi art�r
            playerAmmo.ammoCount = Mathf.Clamp(playerAmmo.ammoCount, 0, 90); // Maksimum mermi s�n�rla
            playerAmmo.UpdateAmmoText(); // UI'yi g�ncelle

            nextAmmoTime = Time.time + ammoIncreaseDelay; // Bir sonraki art�� s�resini ayarla
        }
    }
}
