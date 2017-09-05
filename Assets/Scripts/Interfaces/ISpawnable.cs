using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable {
    float spawnAreaX { get; }
    void Move();
    void RotateTowards(Vector3 target);
}
