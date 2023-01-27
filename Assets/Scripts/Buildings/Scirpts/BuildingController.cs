using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
    public enum TowerTargetPriority {
        First,
        Close,
        Strongest
    }

    [Header("Enemy Data")]
    public float range;
    private List<Enemy> enemiesInRange = new List<Enemy>();
    private Enemy currentEnemy;
    
    public TowerTargetPriority targetPriority;
    public bool rotateTowardsTarget;

    [Header("Combat")]
    private float timeSinceLastAttack;
    public float attackRate;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPos;

    public int projectileDamage;
    public float projectileSpeed;
    public int cost;

    // Update is called once per frame
    void Update()
    {
       if (timeSinceLastAttack == 0) {
            currentEnemy = getEnemy();

            if (currentEnemy != null) {
                attack();
                timeSinceLastAttack = attackRate;
            }
       }

        else if (timeSinceLastAttack >= 0) {
            timeSinceLastAttack -= Time.deltaTime;

            if (timeSinceLastAttack <= 0) {
                timeSinceLastAttack = 0;
            }
        }
    }

    private Enemy getEnemy() {
        enemiesInRange.RemoveAll(x => x == null);

        if(enemiesInRange.Count == 0) {
            return null;
        }

        if(enemiesInRange.Count == 1) {
            return enemiesInRange[0];
        }

        else {
            return enemiesInRange[0];
        }
        
        //For later addition of targeting priority
        /*switch(targetPriority) {
            case TowerTargetPriority.Close:
                return enemiesInRange[0];
        }*/
        
        //return null;
    }

    private void attack() {
        if (rotateTowardsTarget) {
            transform.LookAt(currentEnemy.transform);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }

        GameObject proj = Instantiate(projectilePrefab, projectileSpawnPos.position, Quaternion.identity);
        proj.GetComponent<Projectile>().initialize(currentEnemy, projectileDamage, projectileSpeed);
    }

    public void OnBuildingPlaced() {
        GameManager.instance.onTowerPlaced();
    }
    
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Enemy")) {
            enemiesInRange.Add(other.GetComponent<Enemy>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Enemy")) {
            enemiesInRange.Remove(other.GetComponent<Enemy>());
        }
    }
}