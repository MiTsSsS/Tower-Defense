using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager instance;

    private List<Enemy> m_enemies;

    // Start is called before the first frame update
    void Start() {
        instance = this;

        m_enemies = new List<Enemy>();
    }

    public void addEnemy(Enemy enemy) {
        m_enemies.Add(enemy);
    }

    public void removeEnemy(Enemy enemy) {
        m_enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    public void clearEnemies() {
        foreach(Enemy enemy in m_enemies) {
            Destroy(enemy.gameObject);
        }

        m_enemies.Clear();
    }
}
