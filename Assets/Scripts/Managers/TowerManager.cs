using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public enum TowerType {
        Normal,
        Fast,
        Heavy
    }

    public BuildingBlueprint buildingBlueprint;
    
    private bool canShowPreview = true;

    public GameObject towerPreview;
    public GameObject normalTower;
    public GameObject heavyTower;
    public GameObject fastTower;
    private GameObject selectedTower;

    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            if(buildingBlueprint.towerPreview != null) {
                deselectTower();
            }
        }
    }

    private GameObject getTowerByType(TowerType type) {
        switch (type) {
            case TowerType.Normal:
                return normalTower;

            case TowerType.Fast:
                return fastTower;

            case TowerType.Heavy:
                return heavyTower;
        }

        return null;
    }

    public void createTowerPreview(int type) {
        GameObject selectedTowerPreview = getTowerByType((TowerType)type);
        buildingBlueprint.setSelectedTower(selectedTowerPreview);

        Debug.Log(canShowPreview);

        if (selectedTowerPreview != null && canShowPreview) {
            buildingBlueprint.towerPreview = Instantiate(towerPreview, transform.position, Quaternion.identity);
            canShowPreview = false;
        }
    }

    public void OnTowerPlaced() {
        buildingBlueprint.towerPreview = null;
        canShowPreview = true;
    }

    public void deselectTower() {
        Destroy(buildingBlueprint.towerPreview);
        
        selectedTower = null;
        canShowPreview = true;
    }
}
