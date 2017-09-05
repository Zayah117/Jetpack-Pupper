using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour {
    public float speed;

	void Update () {
        transform.position += -transform.up * speed * Time.deltaTime * GameController.instance.speedMultiplier;
	}

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            transform.position = new Vector3(0, transform.parent.transform.position.y, 0);
            transform.parent.GetComponentInParent<Spawner>().SpawnObject();
        }
    }
}
