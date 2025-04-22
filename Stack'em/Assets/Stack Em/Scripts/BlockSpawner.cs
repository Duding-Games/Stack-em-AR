using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs; // Array de bloques prefabricados
    public Transform spawnPoint; // Punto donde aparecerán los bloques
    public float spawnInterval = 2f; // Tiempo entre spawns
    public float checkInterval = 0.1f; // Tiempo entre comprobaciones
    public float spawnRange = 0.001f; // Rango de variación horizontal
    public float minGravity = 0.5f; // Gravedad mínima
    public float maxGravity = 2f; // Gravedad máxima

    public GameManager gayManager;

    void Start()
    {
        StartCoroutine(SpawnBlocks());
    }

    IEnumerator SpawnBlocks()
    {
        // Esperar hasta que el juego esté activo
        while (!gayManager.gameActive)
        {
            yield return new WaitForSeconds(checkInterval);
        }

        // Una vez que el juego esté activo, empezar a spawnear bloques
        while (true)
        {
            SpawnBlock();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBlock()
    {
        if (blockPrefabs.Length == 0) return;

        int index = Random.Range(0, blockPrefabs.Length);
        Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

        GameObject newBlock = Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);
        Rigidbody rb = newBlock.GetComponent<Rigidbody>();
        if (rb != null)
        {
            // Puedes descomentar estas líneas si quieres asignar masa aleatoria
            // rb.mass = Random.Range(minGravity, maxGravity);
        }
    }
}
