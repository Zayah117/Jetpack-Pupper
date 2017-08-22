using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public float speed;

    float offSetY;
    Material mat;

    void Start() {
        mat = GetComponent<Renderer>().material;
    }

    void Update () {
        offSetY += speed * GameController.instance.speedMultiplier;

        mat.SetTextureOffset("_MainTex", new Vector2(0, offSetY));
	}
}
