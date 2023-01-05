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

    private GameObject selectedTower;
    private bool canShowPreview = true;

    public GameObject normalTower;
    public GameObject heavyTower;
    public GameObject fastTower;

    private void Update() {
        if(Input.GetMouseButtonDown(1)) {
            if(selectedTower != null) {
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

        if (selectedTowerPreview != null && canShowPreview) {
            selectedTower = Instantiate(selectedTowerPreview, transform.position, Quaternion.identity);
            canShowPreview = false;
        }
    }

    public void OnTowerPlaced() {
        selectedTower = null;
        canShowPreview = true;
    }

    public void deselectTower() {
        Destroy(selectedTower);
        
        selectedTower = null;
    }
}
