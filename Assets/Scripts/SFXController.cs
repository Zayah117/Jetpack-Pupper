using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXController : MonoBehaviour {
    public static SFXController instance;
    public SFX sfx;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    public void AsteriodExplosion(Vector3 pos, float scale) {
        GameObject explosion = Instantiate(sfx.explosionSFX, pos, Quaternion.identity);
        explosion.transform.localScale = new Vector3(scale * 0.5f, scale * 0.5f, scale * 0.5f);
    }
}
