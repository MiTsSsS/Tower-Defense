using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject m_enemyPrefab;
    [SerializeField]
    private float m_spawnInterval;
    [SerializeField]
    private Transform m_spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnEnemy", 0, m_spawnInterval);
    }

    public void spawnEnemy() {
        Instantiate(m_enemyPrefab, m_spawnPosition);
    }
}
