using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelBar : MonoBehaviour {
    public PupperController pupper;

    RectTransform rectTransform;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        rectTransform.localScale = new Vector3(1, pupper.fuel);
    }
}
