using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour {
    [Header("Set in Inspector")]
    public float leftX = -20f;
    public float rightX = 20f;
    public float bottomY = -20f;                                 

    void Update () {
        if (transform.position.y < bottomY || transform.position.x < leftX || transform.position.x > rightX) {
            DestroyImmediate(gameObject);
        }
    }
}