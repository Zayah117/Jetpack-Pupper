using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : MonoBehaviour, ISpawnable {
    public Sprite[] asteroidTextures;
    public float minSpeed;
    public float maxSpeed;
    public float minScale;
    public float maxScale;
    public float scale;
    public Vector3 target;

    float moveSpeed;
    float _spawnAreaX = 3.0f;

    public float spawnAreaX {
        get { return _spawnAreaX; }
    }

    void Awake() {
        SetSprite();
        moveSpeed = Random.Range(minSpeed, maxSpeed);
        scale = Random.Range(minScale, maxScale);
        gameObject.transform.localScale = new Vector3(scale, scale);
    }

    void Update() {
        Move();
    }

    void SetSprite() {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        sr.sprite = asteroidTextures[Random.Range(0, asteroidTextures.Length)];

        if (Random.Range(0.0f, 1.0f) > 0.5f)
            sr.flipX = true;
        if (Random.Range(0.0f, 1.0f) > 0.5f)
            sr.flipY = true;
    }

    public void Move() {
        transform.position += transform.up * Time.deltaTime * moveSpeed * GameController.instance.speedMultiplier;
    }

    public void RotateTowards(Vector3 target) {
        transform.up = target - transform.position;
    }

    public void Expload() {
        AudioController.instance.Explosion(transform.position, scale);
        SFXController.instance.AsteriodExplosion(transform.position, scale);
        Destroy(gameObject);
    }
}
