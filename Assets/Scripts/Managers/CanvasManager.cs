using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject goldText;
    // Start is called before the first frame update
    void Start()
    {
        goldText.GetComponent<TextMeshProUGUI>().text = GameManager.instance.gold.ToString();
    }

    public void updateGoldText(int g) {
        goldText.GetComponent<TextMeshProUGUI>().text = g.ToString();
    }
}
