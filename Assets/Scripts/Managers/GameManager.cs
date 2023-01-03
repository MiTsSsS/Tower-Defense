using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject towerPref;

    public int gold = 0;

    public void createTowerPreview() {
        Instantiate(towerPref, transform.position, Quaternion.identity);
    }
}
