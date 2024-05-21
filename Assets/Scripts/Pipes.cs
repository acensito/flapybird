using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipes : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private float leftLimit;

    void Start() {
        leftLimit = Camera.main.ViewportToWorldPoint(Vector3.zero).x;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < -15.0f) {
            Destroy(gameObject);
        }
    }
}
