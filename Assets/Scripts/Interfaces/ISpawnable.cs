using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpawnable {
    void Move();
    void RotateTowards(Vector3 target);
}
