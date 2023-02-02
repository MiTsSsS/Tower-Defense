using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int m_hitPoints;
    public HealthBar m_healthBar;

    public void Start() {
        m_healthBar.setMaxHpValue(m_hitPoints);
    }

    public void takeDamage(int damage) {
        m_hitPoints -= damage;
        m_healthBar.setHp(m_hitPoints);

        Debug.Log(m_hitPoints);

        if(m_hitPoints <= 0) {
            onDeath();
        }
    }

    private void onDeath() {
        GameManager.instance.gainGold(10);
        GameManager.instance.removeEnemy(this);
    }
}
