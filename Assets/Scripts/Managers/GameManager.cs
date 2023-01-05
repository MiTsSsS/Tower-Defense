using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int gold;

    [SerializeField]
    private TowerManager towerManager;

    private void Start() {
        instance = this;
    }

    public bool validateBuildingCost(int buildingCost) {
        bool canPlace = gold >= buildingCost;

        if (canPlace) {
            spendGold(buildingCost);    
        }
        
        else {
            //Let the player know they can't build the tower
        }

        return canPlace;
    }

    private void spendGold(int g) {
        gold -= g;
        
        
    }

    public void onTowerPlaced() {
        towerManager.OnTowerPlaced();
    }
}
