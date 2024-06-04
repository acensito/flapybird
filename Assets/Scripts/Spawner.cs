using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour {

    [SerializeField] private GameObject pipePrefab;
    [SerializeField] private float spawnTime = 2.0f;
    [SerializeField] private float minHeight = -1.0f;
    [SerializeField] private float maxHeight = 1.0f;

    // Update is called once per frame
    void OnEnable() {
        InvokeRepeating(nameof(SpawnPipe), spawnTime, spawnTime);
    }

    void OnDisable() {
        CancelInvoke(nameof(SpawnPipe));
    }

    void SpawnPipe() {
        Vector3 spawnPosition = transform.position;
        spawnPosition.y += Random.Range(minHeight, maxHeight);
        Instantiate(pipePrefab, spawnPosition, Quaternion.identity, GameObject.Find("Spawner").transform);
    }
}