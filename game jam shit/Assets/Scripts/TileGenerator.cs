using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(Random.Range(0,tilePrefabs.Length));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnTile(int tileIndex)
    {
        Instantiate(tilePrefabs[tileIndex], transform.position, transform.rotation);
    }
}
