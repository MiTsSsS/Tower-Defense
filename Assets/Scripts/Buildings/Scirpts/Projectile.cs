using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Enemy m_target;
    private int m_damage;
    private float m_speed;

    public GameObject hitSpawnPrefab;

    public void initialize(Enemy target, int damage, float speed) {
        m_target = target;
        m_damage = damage;
        m_speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
       if(m_target != null) {
            transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, m_speed * Time.deltaTime);
            transform.LookAt(m_target.transform);

            if(Vector3.Distance(transform.position, m_target.transform.position) < .2f) {
                m_target.takeDamage(m_damage);

                if (hitSpawnPrefab != null) {
                    Instantiate(hitSpawnPrefab, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
       }
       
       else {
            Destroy(gameObject);
       }
    }
}
