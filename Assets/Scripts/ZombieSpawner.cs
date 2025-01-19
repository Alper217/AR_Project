using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Spawnlanacak zombi prefabý
    public GameObject player;       // Ana karakter (Player)
    public float spawnRadius = 10f; // Ana karakterden uzaklýk
    public int spawnCount = 5;      // Ayný anda spawnlanacak zombi sayýsý
    public float spawnInterval = 3f; // Zombilerin spawnlanma aralýðý (saniye)

    private void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    private IEnumerator SpawnZombies()
    {
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                SpawnZombie();
            }
            yield return new WaitForSeconds(spawnInterval); // Belirtilen süre kadar bekle
        }
    }

    private void SpawnZombie()
    {
        // Rastgele bir açý belirle (360 derece içinde)
        float angle = Random.Range(0, Mathf.PI * 2);

        // Ana karakterin etrafýnda rastgele bir nokta hesapla
        Vector3 spawnPosition = player.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * spawnRadius;

        // Zombi prefabýný spawnla
        GameObject spawnedZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

        // ZombieController'a player referansýný aktar
        ZombieController zombieController = spawnedZombie.GetComponent<ZombieController>();
        if (zombieController != null)
        {
            zombieController.player = player.transform;
        }
    }
}
