using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {

    public GameObject[] tilePrefabs;

    public float zSpawn = 0;
    public float tileLength = 9;
    public int numTiles = 10;

    public Transform playerTransform;

    // Start is called before the first frame update
    void Start() {

        for (int i = 0; i < numTiles; i++) {
            if (i == 0) SpawnTile(0);
            else SpawnTile(Random.Range(0, tilePrefabs.Length));
        }

    }

    // Update is called once per frame
    void Update() {
        if (playerTransform.position.z > zSpawn - numTiles * tileLength) {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
        }
    }

    public void SpawnTile(int tileIndex) {

        Instantiate(tilePrefabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }
}
