using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    public GameObject goldText;
    public Slider arrivalScoreSlider;
        
    // Start is called before the first frame update
    void Start()
    {
        goldText.GetComponent<TextMeshProUGUI>().text = GameManager.instance.getGold().ToString();
    }

    public void updateGoldText(int g) {
        goldText.GetComponent<TextMeshProUGUI>().text = g.ToString();
    }

    public void setArrivalScoreSlider(int value) {
        arrivalScoreSlider.value = value;
    }

    public void resetArrivalBar() {
        arrivalScoreSlider.value = 0;
    }
}
