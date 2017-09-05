using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour {

    RectTransform rectTransform;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update () {
        rectTransform.localScale = new Vector3(1, GameController.instance.speedMultiplier);
	}
}
