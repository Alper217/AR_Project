using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoTaker : MonoBehaviour
{
    public GameObject player;
    private ShotAndReload playerAmmo;

    public int ammoIncreaseAmount = 1; // Her artýþta eklenecek mermi miktarý
    public float ammoIncreaseDelay = 1f; // Mermi artýþ aralýðý (saniye)
    private float nextAmmoTime = 0f; // Bir sonraki artýrma zamaný

    void Start()
    {
        if (player != null)
        {
            playerAmmo = player.GetComponent<ShotAndReload>();
            if (playerAmmo == null)
            {
                Debug.LogError("ShotAndReload scripti player üzerinde bulunamadý.");
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // Eðer oyuncu alanda ve belirli süre geçmiþse mermi ekle
        if (playerAmmo != null && Time.time >= nextAmmoTime)
        {
            playerAmmo.ammoCount += ammoIncreaseAmount; // Belirtilen miktarda mermi artýr
            playerAmmo.ammoCount = Mathf.Clamp(playerAmmo.ammoCount, 0, 90); // Maksimum mermi sýnýrla
            playerAmmo.UpdateAmmoText(); // UI'yi güncelle

            nextAmmoTime = Time.time + ammoIncreaseDelay; // Bir sonraki artýþ süresini ayarla
        }
    }
}
