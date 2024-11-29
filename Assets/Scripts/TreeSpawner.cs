using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour
{
    private BuildingManager buildingManager;
    private List<GameObject> unoccupiedDirtTiles = new List<GameObject>();

    private void Start()
    {
        buildingManager = BuildingManager.Instance;

        GameObject[] dirtTiles = GameObject.FindGameObjectsWithTag("Dirt");
        unoccupiedDirtTiles.AddRange(dirtTiles);

        StartCoroutine(SpawnTree());
    }

    private IEnumerator SpawnTree()
    {
        while (unoccupiedDirtTiles.Count > 0)
        {
            yield return new WaitForSeconds(1);

            if(unoccupiedDirtTiles.Count > 0)
            {
                int randomIndex = Random.Range(0, unoccupiedDirtTiles.Count);

                GameObject selectedDirtTile = unoccupiedDirtTiles[randomIndex];
                var selectedNode = selectedDirtTile.GetComponent<BuildableNode>();

                buildingManager.BuildTreeOn(selectedNode);

                unoccupiedDirtTiles.RemoveAt(randomIndex);
            }
        }

        Debug.Log("Tree is finished planting");
    }

    public void RemoveDirtTile(GameObject tile)
    {
        if(unoccupiedDirtTiles.Contains(tile))
        {
            unoccupiedDirtTiles.Remove(tile);
        }
    }
}
