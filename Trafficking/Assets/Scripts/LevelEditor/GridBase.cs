using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBase : MonoBehaviour
{
    public GameObject nodePrefab;

    public int sizeX;
    public int sizeZ;
    public int offset = 1;

    public Node[,] grid;

    private static GridBase instance = null;
    public static GridBase GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        instance = this;
        CreateGrid();
        CreateMouseCollision();
    }

    void CreateGrid()
    {
        grid = new Node[sizeX, sizeZ];

        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                // scale of art assets/models is 7:1 for unity
                float posX = x * offset * 7;
                float posZ = z * offset * 7;

                GameObject go = Instantiate(nodePrefab, new Vector3(posX, 0, posZ), Quaternion.identity) as GameObject;
                go.transform.parent = transform.GetChild(1).transform;

                NodeObject nodeObj = go.GetComponent<NodeObject>();
                nodeObj.posX = x;
                nodeObj.posZ = z;

                Node node = new Node();
                node.vis = go;
                node.tileRenderer = node.vis.GetComponentInChildren<MeshRenderer>();
                node.isWalkable = true;
                node.nodePosX = x;
            }
        }
    }

    /// <summary>
    /// Detects mouse collision and mouse clicks on specific parts of the grid
    /// </summary>
    void CreateMouseCollision()
    {
        GameObject go = new GameObject();
        go.AddComponent<BoxCollider>();
        go.GetComponent<BoxCollider>().size = new Vector3(sizeX * offset, 0.1f, sizeZ * offset);
        // transform position takes into consideration that the grid starts from center
        go.transform.position = new Vector3((sizeX * offset) / 2 - 1, 0, (sizeZ * offset) / 2 - 1);
    }

    /// <summary>
    /// Obtains node from selection in world position
    /// </summary>
    public Node NodeFromWorldPosition(Vector3 worldPosition)
    {
        float worldX = worldPosition.x;
        float worldZ = worldPosition.z;

        worldX /= offset;
        worldZ /= offset;

        int x = Mathf.RoundToInt(worldX);
        int z = Mathf.RoundToInt(worldZ);

        if (x > sizeX)
            x = sizeX;
        if (z > sizeZ)
            z = sizeZ;
        if (x < 0)
            x = 0;
        if (z < 0)
            z = 0;

        return grid[x, z];
    }
}
