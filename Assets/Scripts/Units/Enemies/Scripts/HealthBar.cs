using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    
    public void setMaxHpValue(float value) {
        healthBar.maxValue = value;
        healthBar.value = value;
    }

    public void setHp(float value) {
        healthBar.value = value;
    }
}
