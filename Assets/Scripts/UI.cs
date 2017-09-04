using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public class UI {
    [Header("Panels")]
    public GameObject hudPanel;
    public GameObject gameOverPanel;

    [Header("Images / Sprites")]
    public Image health1;
    public Image health2;
    public Image health3;
    public Image health4;

    // health bar colors
    public Color32 red = new Color32(255, 0, 0, 255);
    public Color32 white = new Color32(255, 255, 225, 100);
}
