using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField]
    private int startingGold;
    [SerializeField]
    private CanvasManager m_canvasManager;
    [SerializeField]
    private TowerManager m_towerManager;
    [SerializeField]
    private UnitManager m_unitManager;
    [SerializeField]
    private Transform m_enemyPathParent;

    private int m_arrivalScore = 0;
    private int m_gold;
    private List<GameObject> m_enemyPathTiles;

    private void Start() {
        instance = this;
        setGold(startingGold);
        InvokeRepeating("gainGoldRepeating", 0, 2f);

        m_enemyPathTiles = new List<GameObject>();
        gatherEnemyPathTiles();
    }

    public bool validateBuildingCost(int buildingCost) {
        bool canPlace = m_gold >= buildingCost;

        if (canPlace) {
            spendGold(buildingCost);    
        }
        
        else {
            //Let the player know they can't build the tower
        }

        return canPlace;
    }

    private void spendGold(int g) {
        setGold(m_gold - g);
    }

    private void gainGoldRepeating() {
        setGold(m_gold + 2);
    }

    public void gainGold(int g) {
        setGold(m_gold + g);
    }

    public void setGold(int g) {
        m_gold = g;
        m_canvasManager.updateGoldText(m_gold);
    }

    public int getGold() {
        return m_gold;
    }

    public void onTowerPlaced() {
        m_towerManager.OnTowerPlaced();
    }

    public void setArrivalScore(int arrivalScore) {
        m_arrivalScore += arrivalScore;
        Debug.Log(m_arrivalScore);

        m_canvasManager.setArrivalScoreSlider(m_arrivalScore);

        if (m_arrivalScore >= 100) {
            Debug.Log("Game Over!!!");
            restartGame();
        }
    }

    public void resetArrivalScore() {
        m_arrivalScore = 0;
    }

    public void addEnemy(Enemy enemy) {
        m_unitManager.addEnemy(enemy);
    }

    public void removeEnemy(Enemy enemy) {
        m_unitManager.removeEnemy(enemy);
    }

    public void addTower(GameObject tower) {
        m_towerManager.addTower(tower);
    }

    private void resetGold() {
        setGold(startingGold);
    }

    private void destroyAllTowers() {
        m_towerManager.clearTowers(); 
    }

    private void destroyAllEnemies() {
        m_unitManager.clearEnemies();
    }

    private void resetEnemyArrivalScore() {
        resetArrivalScore();
        m_canvasManager.resetArrivalBar();
    }

    private void restartGame() {
        resetGold();
        resetEnemyArrivalScore();      
        destroyAllEnemies();
        destroyAllTowers();
    }

    private void gatherEnemyPathTiles() {
        var children = m_enemyPathParent.GetComponentInChildren<Transform>(true);

        foreach(Transform enemyPathTile in children) {
            if(enemyPathTile.gameObject.layer == 7) {
                m_enemyPathTiles.Add(enemyPathTile.Find("RedZone").gameObject);
            }
        }
    }

    public void toggleRedZone(bool isActive) {
        foreach(GameObject redZone in m_enemyPathTiles) {
            redZone.SetActive(isActive);
        }
    }
}