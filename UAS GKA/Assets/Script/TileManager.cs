using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 22.5f;
    private int amnTilesOnScreen = 3;

    public GameObject sky;
    public GameObject mountain;
    public GameObject cloud;
    float positionIncrement = 0;

    void Start()
    {
        sky = GameObject.Find("sky");
        mountain = GameObject.Find("Mountain");
        cloud = GameObject.Find("Cloud");

        playerTransform = GameObject.FindGameObjectWithTag("Fox").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTiles();
        }
    }

    void Update()
    {
        if (playerTransform.position.z > (spawnZ - amnTilesOnScreen * tileLength))
        {
            SpawnTiles();

            transformPosition(sky);
            transformPosition(mountain);
            transformPosition(cloud);
        }
    }

    void SpawnTiles(int prefabIndex = -1)
    {
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
    }

    void transformPosition(GameObject obj) {
        positionIncrement += 10.0f;
        obj.transform.position = new Vector3(transform.position.x, transform.position.x, transform.position.z + positionIncrement);
    }
}
