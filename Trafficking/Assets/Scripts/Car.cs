using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //test variables
    public Transform testNode;
    public bool turnLeft = false;

    public Transform path;
    public float carSpeed;
    [SerializeField] private List<Transform> nodes;
    private int currentNode = 0;
    private Transform _transform;

    // Variables for Quaternion rotation
    Vector3 relativePos = Vector3.zero;
    Quaternion targetRot;
    public Transform target;
    bool rotating = false;
    float rotationTime = 0f;
    Quaternion startRot;

    // Variables for Vector3 rotation
    Transform startPos;
    Transform endPos;
    float startTime = 0f;
    float journeyTime = 0f;
    Vector3 centerPoint = Vector3.zero;
    Vector3 startRelCenter = Vector3.zero;
    Vector3 endRelCenter = Vector3.zero;






    private void Start()
    {

        _transform = transform;
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

    void Turn()
    {
        if(startTime == 0.0f)
        {
            startTime = Time.time;
            target = nodes[currentNode];
            startPos = nodes[currentNode - 1];
            endPos = nodes[currentNode];
            startRot = _transform.rotation;
            
        }
        if (turnLeft)
        {
            targetRot.eulerAngles = new Vector3(0, -90, 0);
        }
        else
        {
            targetRot.eulerAngles = new Vector3(0, 90, 0);
        }
        //relativePos = target.position - _transform.position;
        //targetRot = Quaternion.LookRotation(relativePos, Vector3.up);
        

        GetCenter(Vector3.left);
        float fracComplete = (Time.time - startTime) / GetJourneyTime(startPos, endPos) ;
        _transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete);
        transform.rotation = Quaternion.Lerp(startRot, targetRot, fracComplete);
        _transform.position += centerPoint;
    }

    void GetCenter(Vector3 dir)
    {
        centerPoint = (startPos.position + endPos.position) * 0.5f;
        centerPoint -= dir;
        startRelCenter = startPos.position - centerPoint;
        endRelCenter = endPos.position - centerPoint;

    }

    float GetJourneyTime(Transform a, Transform b)
    {
        float distance = Mathf.Sqrt(((a.position.x-b.position.x) * (a.position.x -b.position.x)) + ((a.position.z - b.position.z) * (a.position.z -b.position.z)));
        distance /= 2;
        distance = Mathf.PI * distance;
        return distance / carSpeed;

    }

    private void Drive()
    {
        if (nodes[currentNode] == testNode)
        {
            Debug.Log("Start time : " + startTime);
            Debug.Log("Turning");
            Turn();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, Time.deltaTime * carSpeed);
        }
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
            if (currentNode < nodes.Count-1)
            {
                currentNode++;
            }
        }
    }

    private void Rotate()
    {

    }
}
