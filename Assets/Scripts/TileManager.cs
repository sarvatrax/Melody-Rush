using NUnit.Framework;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePreFabs;
    public float zSpawn = 0;
    public float tileLength = 18;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>(); 
    public Transform playerTransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {    
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePreFabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - 35 >  zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePreFabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePreFabs[tileIndex], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
