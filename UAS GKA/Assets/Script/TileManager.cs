using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;

    private List<GameObject> activeTiles;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 22.5f;
    private int amnTilesOnScreen = 6;
    private int lastPrefabIndex = 0;

    public GameObject sky;
    public GameObject mountain;
    public GameObject cloud;
    float positionIncrement = 0;

    void Start()
    {
        activeTiles = new List<GameObject>();
        sky = GameObject.Find("sky");
        mountain = GameObject.Find("Mountain");
        cloud = GameObject.Find("Cloud");
        playerTransform = GameObject.FindGameObjectWithTag("Fox").transform;

        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            if (i < 2)
                SpawnTiles(0);
            else
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
        if (prefabIndex == -1)
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        else
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    void transformPosition(GameObject obj) {
        positionIncrement += 7.5f;
        obj.transform.position = new Vector3(transform.position.x, transform.position.x, transform.position.z + positionIncrement);
    }

    private int RandomPrefabIndex()
    {
        if (tilePrefabs.Length <= 1)
            return 0;

        int randomIndex = lastPrefabIndex;
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }

        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
