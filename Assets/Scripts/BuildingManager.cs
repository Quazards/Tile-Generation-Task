using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    [SerializeField] private GameObject tree;
    [SerializeField] private GameObject house;

    [HideInInspector] public TreeSpawner treeSpawner;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        treeSpawner = GetComponent<TreeSpawner>();
    }

    public void BuildTreeOn(BuildableNode node)
    {
        Instantiate(tree, node.transform.position, Quaternion.identity);
        node.isOccupied = true;
    }

    public void BuildHouseOn(BuildableNode node)
    {
        Instantiate(house, node.transform.position, Quaternion.identity);
        treeSpawner.RemoveDirtTile(node.gameObject);
        node.isOccupied = true;

        if (!node.IsDirtTile())
        {
            PlayerScore.Score += 2;
        }
        else
        {
            PlayerScore.Score += 10;
        }
    }

}
