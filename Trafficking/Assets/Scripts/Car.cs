using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform path;
    public float carSpeed;

    [SerializeField] private List<Transform> nodes;
    private int currentNode = 0;

    private void Start()
    {
        Transform[] pathTransform = path.GetComponentsInChildren<Transform>();
        nodes = new List<Transform>();

        for (int i=0; i<pathTransform.Length; i++)
        {
            if (pathTransform[i] != path.transform)
            {
                nodes.Add(pathTransform[i]);
            }
        }
    }

    private void Update()
    {
        Drive();
        CheckWaypointDistance();
    }

    private void Drive()
    {
        transform.position = Vector3.Lerp(transform.position, nodes[currentNode].position, Time.deltaTime * carSpeed);
        //transform.Translate(nodes[currentNode].position * Time.deltaTime);
    }

    private void CheckWaypointDistance()
    {
        if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.05f)
        {
            //if (currentNode == nodes.Count - 1)
            //{
            //    currentNode = 0;
            //}
            //else
            //{
            //    currentNode++;
            //}
            if (currentNode < nodes.Count)
            {
                currentNode++;
            }
        }
    }

    private void Rotate()
    {

    }
}
