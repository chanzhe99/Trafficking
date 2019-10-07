using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //test variables
    public LayerMask layer;
    //public Transform testNode;
    //public bool turnLeft = false;

    //public Transform path;
    public float carSpeed;
    [SerializeField] private Transform[] nodes;
    [SerializeField] private int currentNode = 0;
    private Transform _transform;
    [SerializeField]private TrafficLight curTraffic;
    private bool turningRight = false;
    
    

    // Variables for Quaternion rotation
    Vector3 relativePos = Vector3.zero;
    Quaternion targetRot;
    public Transform target;
    bool rotating = false;
    //float rotationTime = 0f;
    Quaternion startRot;
    Quaternion self;

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
        nodes = new Transform[5];
        self = _transform.rotation;
        currentNode = 0;
        if(curTraffic != null)
            InitNodes();
        
    }

    private void Update()
    {
        GetNodes();
        if (!CheckToStop())
        {
            CheckTrafficLight();
            if (currentNode == 0 || currentNode == 4 || currentNode == 1)
            {
                Drive();
            }
            else if (currentNode == 2 || currentNode == 3)
            {
                Turn();
            }

        }
        Debug.Log("startTime: " + startTime);
        //CheckWaypointDistance();
    }

    void Turn()
    {
        if(startTime == 0.0f)
        {
            startTime = Time.time;
            target = nodes[currentNode];
            if (curTraffic.Left)
            {
                startPos = nodes[0];
                endPos = nodes[currentNode];
            }
            else
            {
                startPos = nodes[4];
                endPos = nodes[currentNode];
            }
            
            startRot = _transform.rotation; 
        }
        if (curTraffic.Left)
        {
            targetRot.eulerAngles = new Vector3(0, self.eulerAngles.y-90, 0);
        }
        else
        {
            targetRot.eulerAngles = new Vector3(0, self.eulerAngles.y + 90, 0);
        }
        //relativePos = target.position - _transform.position;
        //targetRot = Quaternion.LookRotation(relativePos, Vector3.up);
        GetCenter(Vector3.left);
        float fracComplete = (Time.time - startTime) / GetJourneyTime(startPos, endPos) ;
        _transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete);
        _transform.rotation = Quaternion.Lerp(startRot, targetRot, fracComplete);
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
        startTime = 0f;
        turningRight = false;
        transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, Time.deltaTime * carSpeed);
        Debug.Log("Drove");
        //transform.Translate(nodes[currentNode].position * Time.deltaTime);
    }

    //private void CheckWaypointDistance()
    //{
    //    if (Vector3.Distance(_transform.position, nodes[currentNode].position) < 0.05f)
    //    {
    //        //if (currentNode == nodes.Count - 1)
    //        //{
    //        //    currentNode = 0;
    //        //}
    //        //else
    //        //{
    //        //    currentNode++;
    //        //}
    //        if (currentNode < nodes.Count-1)
    //        {
    //            currentNode++;
    //        }
    //    }
    //}

    private bool CheckToStop()
    {
        RaycastHit hit;
        //Debug.DrawRay(_transform.position, Vector3.left+ new Vector3(-2,0,0), Color.red);
        if (Physics.Raycast(_transform.position, Vector3.left, out hit, 2f, layer))
        {
            if (hit.transform.gameObject.CompareTag("Car"))
            {
                Debug.Log("Hit car");
                return true;
            }
            else
                return false;
        }
        else
            return false;
    }

    void GetNodes()
    {
        if(currentNode == 1 || currentNode == 2 || currentNode == 3)
        {
            if(Vector3.Distance(_transform.position, nodes[currentNode].position) < 0.05f)
            {
                GameObject tempObj;
                curTraffic = nodes[currentNode].gameObject.GetComponent<TrafficNode>().entranceTraffic;
                tempObj = curTraffic.gameObject;
                if (tempObj.CompareTag("CrossLight"))
                {
                    nodes[0] = curTraffic.stop;
                    nodes[1] = curTraffic.straight;
                    nodes[2] = curTraffic.left;
                    nodes[3] = curTraffic.right;
                    nodes[4] = curTraffic.tempDelayRight;
                }
                else if (tempObj.CompareTag("StraightLight"))
                {
                    nodes[0] = curTraffic.stop;
                    nodes[1] = curTraffic.straight;
                }
                else if (tempObj.CompareTag("TurnRightLight"))
                {
                    nodes[0] = curTraffic.stop;
                    nodes[1] = curTraffic.straight;
                    nodes[3] = curTraffic.right;
                    nodes[4] = curTraffic.tempDelayRight;
                }
                else if(tempObj.CompareTag("TurnLeftLight"))
                {
                    nodes[0] = curTraffic.stop;
                    nodes[1] = curTraffic.straight;
                    nodes[2] = curTraffic.left;
                }
            }
        }
    }

    void InitNodes()
    {
        GameObject tempObj;
        tempObj = curTraffic.gameObject;
        if (tempObj.CompareTag("CrossLight"))
        {
            nodes[0] = curTraffic.stop;
            nodes[1] = curTraffic.straight;
            nodes[2] = curTraffic.left;
            nodes[3] = curTraffic.right;
            nodes[4] = curTraffic.tempDelayRight;
        }
        else if (tempObj.CompareTag("StraightLight"))
        {
            nodes[0] = curTraffic.stop;
            nodes[1] = curTraffic.straight;
        }
        else if (tempObj.CompareTag("TurnRightLight"))
        {
            nodes[0] = curTraffic.stop;
            nodes[1] = curTraffic.straight;
            nodes[3] = curTraffic.right;
            nodes[4] = curTraffic.tempDelayRight;
        }
        else if (tempObj.CompareTag("TurnLeftLight"))
        {
            nodes[0] = curTraffic.stop;
            nodes[1] = curTraffic.straight;
            nodes[2] = curTraffic.left;
        }
    }

    private void CheckTrafficLight()
    {

        if (curTraffic.Stop)
        {
            currentNode = 0;
        }
        else if (curTraffic.Straight)
        {
            currentNode = 1;
        }
        else if (curTraffic.Left)
        {
            currentNode = 2;
        }
        else if (curTraffic.Right)
        {
            if (!turningRight)
            {
                currentNode = 4;
                if (Vector3.Distance(_transform.position, nodes[currentNode].position) < 0.05f)
                {
                    currentNode = 3;
                    turningRight = true;
                }
            }
        }
    }
}
