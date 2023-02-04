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
    private List<GameObject> m_towers;

    public GameObject towerPreview;
    public GameObject normalTower;
    public GameObject heavyTower;
    public GameObject fastTower;

    private void Start() {
        m_towers = new List<GameObject>();
    }

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

    public void addTower(GameObject tower) {
        m_towers.Add(tower);
    }

    public void clearTowers() {
        foreach (GameObject tower in m_towers) {           
            Destroy(tower);
        }

        m_towers.Clear();
    }

    public void createTowerPreview(int type) {
        GameObject selectedTowerPreview = getTowerByType((TowerType)type);
        buildingBlueprint.setSelectedTower(selectedTowerPreview);

        if (selectedTowerPreview != null && canShowPreview) {
            buildingBlueprint.towerPreview = Instantiate(towerPreview, transform.position, Quaternion.identity);
            canShowPreview = false;
            GameManager.instance.toggleRedZone(true);
        }
    }

    public void OnTowerPlaced() {
        canShowPreview = true;
        GameManager.instance.toggleRedZone(false);
    }

    public void deselectTower() {
        GameManager.instance.toggleRedZone(false);
        Destroy(buildingBlueprint.towerPreview);
        canShowPreview = true;
    }
}
