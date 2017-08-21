using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithDelay : MonoBehaviour {
    public float delay = 3;

	void Start () {
        Invoke("DestroyObject", delay);
	}
	
    void DestroyObject() {
        Destroy(gameObject);
    }
}
