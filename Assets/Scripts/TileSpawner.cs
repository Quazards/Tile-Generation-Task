using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] tilePrefabs;
    [SerializeField] private Transform[] tilePosition;

    private void Awake()
    {
        SpawnTile();
    }

    private void SpawnTile()
    {
        int[] tileIndex = new int[tilePosition.Length];

        for (int i = 0; i < tilePrefabs.Length; i++)
        {
            tileIndex[i] = i;
        }

        for(int i = tilePrefabs.Length; i < tileIndex.Length; i++)
        {
            tileIndex[i] = Random.Range(0, tilePrefabs.Length);
        }

        for(int i = 0; i < tilePosition.Length; i++)
        {
            Instantiate(tilePrefabs[tileIndex[i]], tilePosition[i].position, Quaternion.identity, tilePosition[i]);
        }
    }
}
