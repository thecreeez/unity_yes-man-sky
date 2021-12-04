using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public GameObject lastCreatedTile;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TileMover.instance.tiles.Count < 1)
            SpawnTile(Random.Range(0, tilePrefabs.Length));

        if (lastCreatedTile.transform.position.z <= transform.position.z - 20)
            SpawnTile(Random.Range(0, tilePrefabs.Length));
    }

    private void SpawnTile(int tileIndex)
    {
        lastCreatedTile = Instantiate(tilePrefabs[tileIndex], transform.position, transform.rotation);
        TileMover.instance.tiles.Add(lastCreatedTile);
    }
}
