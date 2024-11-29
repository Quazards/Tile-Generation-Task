using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableNode : MonoBehaviour
{
    public bool isOccupied = false;

    private BuildingManager buildingManager;

    [SerializeField] private GameObject curretTile;

    public bool IsDirtTile()
    {
        if (curretTile.tag == "Dirt")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Start()
    {
        buildingManager = BuildingManager.Instance;
    }

    private void OnMouseDown()
    {
        if(!isOccupied)
        {
            buildingManager.BuildHouseOn(this);
        }
    }
}
