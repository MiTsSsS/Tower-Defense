using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationPointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        GameManager.instance.setArrivalScore(10);
        UnitManager.instance.removeEnemy(other.GetComponent<Enemy>());
    }
}
