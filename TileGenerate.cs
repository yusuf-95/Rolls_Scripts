using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileGenerate : MonoBehaviour
{

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = -1.0f;
    private float tileLength = 20.0f;
    private int tilesOnScreen = 7;
    private int lastPrefabIndex = 0;
    private float safeZone = 20.0f;

    private List<GameObject> activeTiles;

    // Use this for initialization
    void Start()
    {

        activeTiles = new List<GameObject>();

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < tilesOnScreen; i++)

        {

            if (i < 2)

                SpawnTile(0);

            else

                SpawnTile();

        }

    }
    void Update()

    {

        if (playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength))

        {
            SpawnTile();

            DeleteTile();

        }

    }

    private void SpawnTile(int prefabIndex = -1)

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

    private void DeleteTile()

    {
        Destroy(activeTiles[0]);

        activeTiles.RemoveAt(0);

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
