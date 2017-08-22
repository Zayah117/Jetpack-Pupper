using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerText : MonoBehaviour {
    public GameController gameController;
    Text myText;

    float power;

    void Start() {
        myText = GetComponent<Text>();
    }

    void Update() {
        GetPower();
        myText.text = "POWER " + power + "%";
    }

    void GetPower() {
        power = Mathf.Round(gameController.speedMultiplier * 100f);
    }
}
