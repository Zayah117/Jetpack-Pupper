using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    public Transform player;

    private float yOffSet = 2.5f;

    void Start() {
        transform.position = new Vector3(transform.position.x, player.position.y + yOffSet, transform.position.z);
    }
}
