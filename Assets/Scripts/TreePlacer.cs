using UnityEngine;
using System.Collections.Generic;

public class TreeSpawner : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject basePrefab;
    public Material treeMaterial;
    public float spacing = 10f;   // Space between each tree
    public int treeCount = 20;    // Number of trees initially spawned
    public float offsetZ = 0f;    // Starting Z position for the first set of trees
    public float xOffset = 5f;    // Offset for trees on the left and right
    public float treeYOffset = 0f;
    public Transform playerTransform;  // Player's position to spawn trees ahead of them

    private List<GameObject> activeTrees = new List<GameObject>();  // To keep track of active trees
    private float zPos = 0f;

    void Start()
    {
        // Initial spawn of trees
        for (int i = 0; i < treeCount; i++)
        {
            zPos = i * spacing + offsetZ;

            // Left side
            SpawnTreeWithBase(new Vector3(-xOffset, 0, zPos));

            // Right side
            SpawnTreeWithBase(new Vector3(xOffset, 0, zPos));
        }
    }

    void Update()
    {
        // Continuously check and spawn trees if necessary
        CheckAndSpawnTrees();
    }

    // Spawns a tree with a base at the given position
    void SpawnTreeWithBase(Vector3 basePosition)
    {
        GameObject baseObj = Instantiate(basePrefab, basePosition, Quaternion.identity, transform);

        // Set tree position on top of base
        float treeHeightOffset = baseObj.GetComponent<Renderer>().bounds.size.y + treeYOffset;
        Vector3 treePos = basePosition + new Vector3(0, treeHeightOffset, 0);

        GameObject tree = Instantiate(treePrefab, treePos, Quaternion.identity, baseObj.transform);

        if (treeMaterial != null)
        {
            Renderer renderer = tree.GetComponentInChildren<Renderer>();
            if (renderer != null)
                renderer.material = treeMaterial;
        }

        // Add the tree to active trees list
        activeTrees.Add(baseObj);
    }

    // Check if the trees are too far behind and need to be recycled or new ones need to be spawned
    void CheckAndSpawnTrees()
    {
        // Loop through the active trees and check their positions
        for (int i = 0; i < activeTrees.Count; i++)
        {
            GameObject treeBase = activeTrees[i];

            // If the tree base has moved past the player (by a certain distance), recycle it
            if (treeBase.transform.position.z + spacing < playerTransform.position.z)
            {
                // Recycle this tree by moving it to the back
                RecycleTree(treeBase);
            }
        }

        // Spawn new trees ahead of the player
        if (activeTrees.Count > 0)
        {
            GameObject lastTree = activeTrees[activeTrees.Count - 1];

            if (lastTree.transform.position.z < playerTransform.position.z + 30f) // spawn trees 30 units ahead
            {
                SpawnTreeWithBase(new Vector3(-xOffset, 0, lastTree.transform.position.z + spacing));
                SpawnTreeWithBase(new Vector3(xOffset, 0, lastTree.transform.position.z + spacing));
            }
        }
    }

    // Recycle a tree by moving it to the back
    void RecycleTree(GameObject treeBase)
    {
        // Move the tree to the back
        Vector3 newPosition = new Vector3(treeBase.transform.position.x, treeBase.transform.position.y, treeBase.transform.position.z + treeCount * spacing);
        treeBase.transform.position = newPosition;
    }
}
