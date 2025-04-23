using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    public GameObject[] blockPrefabs;
    public Transform spawnPoint;
    public float spawnInterval = 2f;
    public float checkInterval = 0.1f;
    public float spawnRangeX = 1;
    public float spawnRangeZ = 0.3f;

    public GameManager gayManager;

    void Start()
    {
        StartCoroutine(SpawnBlocks());
    }

    IEnumerator SpawnBlocks()
    {
        while (!gayManager.gameActive)
        {
            yield return new WaitForSeconds(checkInterval);
        }

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
        Vector3 spawnPosition = spawnPoint.position + new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, Random.Range(-spawnRangeZ, spawnRangeZ));

        GameObject newBlock = Instantiate(blockPrefabs[index], spawnPosition, Quaternion.identity);
        Rigidbody rb = newBlock.GetComponent<Rigidbody>();
    }
}
