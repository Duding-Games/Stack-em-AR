using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs; // Array de bloques prefabricados
    public Transform spawnPoint; // Punto donde aparecerán los bloques
    public float spawnInterval = 2f; // Tiempo entre spawns
    public float spawnRange = 0.001f; // Rango de variación horizontal
    public float minGravity = 0.5f; // Gravedad mínima
    public float maxGravity = 2f; // Gravedad máxima

    void Start()
    {
        StartCoroutine(SpawnBlocks());
    }

    IEnumerator SpawnBlocks()
    {
        while (true)
        {
            SpawnBlock();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnBlock()
    {
        if (blockPrefabs.Length == 0) return;

        int index = Random.Range(0, blockPrefabs.Length); // Selecciona un bloque aleatorio
        Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));

        GameObject newBlock = Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);
        Rigidbody rb = newBlock.GetComponent<Rigidbody>();
        if (rb != null)
        {
            //rb.useGravity = true;
            //rb.mass = Random.Range(minGravity, maxGravity); // Asigna una gravedad aleatoria mediante la masa
        }
    }
}
