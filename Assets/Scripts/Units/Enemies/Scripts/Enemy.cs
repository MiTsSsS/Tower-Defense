using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   public int m_hitPoints;

   public void takeDamage(int damage) {
        m_hitPoints -= damage;
        Debug.Log(m_hitPoints);
        if(m_hitPoints <= 0) {
            Destroy(gameObject);
        }
   }
}
