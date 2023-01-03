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

    public GameObject normalTower;
    public GameObject heavyTower;
    public GameObject fastTower;

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
        GameObject tower = getTowerByType((TowerType)type);

        if (tower != null) {
            Instantiate(tower, transform.position, Quaternion.identity);
        }
    }
}
