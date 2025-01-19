using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Spawnlanacak zombi prefab�
    public GameObject player;       // Ana karakter (Player)
    public float spawnRadius = 10f; // Ana karakterden uzakl�k
    public int spawnCount = 5;      // Ayn� anda spawnlanacak zombi say�s�
    public float spawnInterval = 3f; // Zombilerin spawnlanma aral��� (saniye)

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
            yield return new WaitForSeconds(spawnInterval); // Belirtilen s�re kadar bekle
        }
    }

    private void SpawnZombie()
    {
        // Rastgele bir a�� belirle (360 derece i�inde)
        float angle = Random.Range(0, Mathf.PI * 2);

        // Ana karakterin etraf�nda rastgele bir nokta hesapla
        Vector3 spawnPosition = player.transform.position + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * spawnRadius;

        // Zombi prefab�n� spawnla
        GameObject spawnedZombie = Instantiate(zombiePrefab, spawnPosition, Quaternion.identity);

        // ZombieController'a player referans�n� aktar
        ZombieController zombieController = spawnedZombie.GetComponent<ZombieController>();
        if (zombieController != null)
        {
            zombieController.player = player.transform;
        }
    }
}
