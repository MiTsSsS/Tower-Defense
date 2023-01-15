using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CanvasManager canvasManager;
    public int gold;

    [SerializeField]
    private TowerManager towerManager;

    private void Start() {
        instance = this;
        setGold(gold);

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
        setGold(gold - g);
    }

    void setGold(int g) {
        gold = g;
        canvasManager.updateGoldText(gold);
    }

    public void onTowerPlaced() {
        towerManager.OnTowerPlaced();
    }
}
