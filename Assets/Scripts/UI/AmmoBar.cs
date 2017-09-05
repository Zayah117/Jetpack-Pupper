using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBar : MonoBehaviour {
    public PupperController pupper;

    RectTransform rectTransform;

    void Start() {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update() {
        float barScale = (float)(pupper.ammo / (pupper.maxAmmo / 100)) / 100.0f;
        rectTransform.localScale = new Vector3(1, barScale);
    }
}
