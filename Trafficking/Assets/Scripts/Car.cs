using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    //test variables
    public LayerMask layer;
    //public Transform testNode;
    //public bool turnLeft = false;
    public enum CarColor { Red, Green, Blue, Orange, Yellow, Purple }
    //public Transform path;
    public float carSpeed;
    [SerializeField] private Transform[] nodes;
    [SerializeField] private int currentNode = 0;
    private Transform _transform;
    [SerializeField] public TrafficLight curTraffic;
    private bool turningRight = false;
    [SerializeField] public CarColor carColor;
    private TurnLights signalLights;
    private bool hasNext = false;
    public float patience = 10f;
    private bool stopped = false;
    private bool increasingP = false;
    private bool decreasingP = false;
    private bool decreasingS = false;
    private int turnNo;
   


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
        signalLights = GetComponent<TurnLights>();
        _transform = transform;
        nodes = new Transform[5];
        self = _transform.rotation;
        currentNode = 0;
        if (curTraffic != null)
            InitNodes();
        

    }

    private void Update()
    {
        GetTurnSignal();
        GetNodes();
        if (!CheckToStop())
        {
            //CheckTrafficLight();
            if (!CheckStopLine())
            {
                if (currentNode == 0)
                {
                    Drive();
                    if (!stopped && !increasingP)
                    {
                        increasingP = true;
                        StartCoroutine(IncreasePatience());
                    }
                    return;
                }
            }
           
            if(curTraffic.canStraightTurn)
            {
                if(currentNode == 1)
                {
                    Drive();
                }
            }
            if(curTraffic.canRightTurn)
            {
                if(currentNode == 4)
                {
                    Drive();
                }
                else if (currentNode == 3)
                {
                    Turn();
                }
            }
            if(curTraffic.canLeftTurn)
            {
                if(currentNode == 2)
                {
                    Turn();
                }
            }
           
            if (!turningRight && currentNode == 4)
            {
                if (Vector3.Distance(_transform.position, nodes[currentNode].position) < 0.01f)
                {
                    currentNode = 3;
                    turningRight = true;
                }
            }
        }
        if (stopped && !decreasingP)
        {
            decreasingP = true;
            StartCoroutine(DecreasePatience());

        }
        if(!stopped && !increasingP)
        {
            increasingP = true;
            StartCoroutine(IncreasePatience());
        }
        if(patience <1 && !decreasingS)
        {
            decreasingS = true;
            StartCoroutine(DecreaseMeter());
        }
        //Debug.Log("startTime: " + startTime);
       
        //CheckWaypointDistance();
    }



    private IEnumerator DecreaseMeter()
    {
        //Debug.Log("Satisfaction: " + Score.Instance.meter);
        Score.Instance.meter -= 1f;
        yield return new WaitForSeconds(1.0f);
        decreasingS = false;
    }

    private IEnumerator DecreasePatience()
    {

        if (patience > 0)
        {
            patience -= 1f;
            //Debug.Log("Patience: " + patience);
        }
        yield return new WaitForSeconds(1.0f);
        decreasingP = false;
    }

    private IEnumerator IncreasePatience()
    {
        if (patience < 11)
        {
            //Debug.Log("Patience: " + patience);
            patience += 1f;
        }
        yield return new WaitForSeconds(1.0f);
        increasingP = false;
    }

    void Turn()
    {
        stopped = false;
        if(startTime == 0.0f)
        {
            startTime = Time.time;
            target = nodes[currentNode];
            if (currentNode == 2)
            {
                startPos = nodes[0];
                endPos = nodes[2];
            }
            else
            {
                startPos = nodes[4];
                endPos = nodes[3];
            }
            self = _transform.rotation;
            startRot = _transform.rotation; 
        }
        if (currentNode == 2)
        {
            targetRot.eulerAngles = new Vector3(self.eulerAngles.x, self.eulerAngles.y-90, self.eulerAngles.z);
        }
        else
        {
            targetRot.eulerAngles = new Vector3(self.eulerAngles.x, self.eulerAngles.y + 90, self.eulerAngles.z);
        }
        //relativePos = target.position - _transform.position;
        //targetRot = Quaternion.LookRotation(relativePos, Vector3.up);
        if(currentNode == 2)
        {
            Vector3 direct = (_transform.TransformDirection(Vector3.right).normalized);
            GetCenter(direct);
        }
        else
        {
            Vector3 direct = (_transform.TransformDirection(Vector3.left).normalized);
            GetCenter(direct);
        }
        
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
        stopped = false;
        startTime = 0f;
        turningRight = false;
        _transform.position = Vector3.MoveTowards(_transform.position, nodes[currentNode].position, Time.deltaTime * carSpeed);
        //Debug.Log("Drove");
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
        
        Vector3 direct = (_transform.TransformDirection(new Vector3(0, 0, 1)).normalized);
        Debug.DrawRay(_transform.position, direct*5f, Color.red);
        if (Physics.Raycast(_transform.position, direct, out hit, 2.3f, layer))
        {
            if (hit.transform.gameObject.CompareTag("Car"))
            {
                stopped = true;
               // Debug.Log("Hit car");
                return true;
            }
            else
            {

                return false;

            }
        }
        else
        {
           // Debug.Log("No hit");
            return false;
        }
    }

    void GetNodes()
    {
        if(currentNode == 1 || currentNode == 2 || currentNode == 3)
        {
            if(Vector3.Distance(_transform.position, nodes[currentNode].position) < 0.025f)
            {
                hasNext = false;
                //GameObject tempObj;

                curTraffic = nodes[currentNode].gameObject.GetComponent<TrafficNode>().entranceTraffic;
                
                //tempObj = curTraffic.gameObject;
                if (curTraffic.stop != null)
                    nodes[0] = curTraffic.stop;
                if (curTraffic.straight != null)
                    nodes[1] = curTraffic.straight;
                if (curTraffic.left != null)
                    nodes[2] = curTraffic.left;
                if (curTraffic.right != null)
                {
                    nodes[3] = curTraffic.right;
                    nodes[4] = curTraffic.tempDelayRight;
                }
                currentNode = 0;
                //if (tempObj.CompareTag("CrossLight"))
                //{
                //    nodes[0] = curTraffic.stop;
                //    nodes[1] = curTraffic.straight;
                //    nodes[2] = curTraffic.left;
                //    nodes[3] = curTraffic.right;
                //    nodes[4] = curTraffic.tempDelayRight;
                //}
                //else if (tempObj.CompareTag("StraightLight"))
                //{
                //    nodes[0] = curTraffic.stop;
                //    nodes[1] = curTraffic.straight;
                //}
                //else if (tempObj.CompareTag("TurnRightLight"))
                //{
                //    nodes[0] = curTraffic.stop;
                //    nodes[1] = curTraffic.straight;
                //    nodes[3] = curTraffic.right;
                //    nodes[4] = curTraffic.tempDelayRight;
                //}
                //else if(tempObj.CompareTag("TurnLeftLight"))
                //{
                //    nodes[0] = curTraffic.stop;
                //    nodes[1] = curTraffic.straight;
                //    nodes[2] = curTraffic.left;
                //}
            }
        }
    }

    void InitNodes()
    {
        if(curTraffic.stop != null)
            nodes[0] = curTraffic.stop;
        if(curTraffic.straight != null)
            nodes[1] = curTraffic.straight;
        if(curTraffic.left != null)
            nodes[2] = curTraffic.left;
        if(curTraffic.right != null)
        {
            nodes[3] = curTraffic.right;
            nodes[4] = curTraffic.tempDelayRight;
        }

        //GameObject tempObj;
        //tempObj = curTraffic.gameObject;

        //if (tempObj.CompareTag("CrossLight"))
        //{
        //    nodes[0] = curTraffic.stop;
        //    nodes[1] = curTraffic.straight;
        //    nodes[2] = curTraffic.left;
        //    nodes[3] = curTraffic.right;
        //    nodes[4] = curTraffic.tempDelayRight;
        //}
        //else if (tempObj.CompareTag("StraightLight"))
        //{
        //    nodes[0] = curTraffic.stop;
        //    nodes[1] = curTraffic.straight;
        //}
        //else if (tempObj.CompareTag("TurnRightLight"))
        //{
        //    nodes[0] = curTraffic.stop;
        //    nodes[1] = curTraffic.straight;
        //    nodes[3] = curTraffic.right;
        //    nodes[4] = curTraffic.tempDelayRight;
        //}
        //else if (tempObj.CompareTag("TurnLeftLight"))
        //{
        //    nodes[0] = curTraffic.stop;
        //    nodes[1] = curTraffic.straight;
        //    nodes[2] = curTraffic.left;
        //}
    }

    bool CheckTrafficStop()
    {
        if(curTraffic.Stop)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }

    void GetTurnSignal()
    {
        turnNo = 0;
        turnNo = FindNextTraffic();
        if (turnNo == 2) //left
        {
            signalLights.leftSignal();
        }
        else if (turnNo == 3 || turnNo == 4) //right
        {
            signalLights.rightSignal();
        }
        else
        {
            signalLights.noSignal();
        }
    }

    //private void CheckTrafficLight()
    //{

    //    if (curTraffic.Stop)
    //    {
    //        currentNode = 0;
    //    }
    //    else if (curTraffic.Straight)
    //    {
    //        currentNode = 1;
    //    }
    //    else if (curTraffic.Left)
    //    {
    //        currentNode = 2;
    //    }
    //    else if (curTraffic.Right)
    //    {
    //        if (!turningRight)
    //        {
    //            currentNode = 4;
    //            if (Vector3.Distance(_transform.position, nodes[currentNode].position) < 0.05f)
    //            {
    //                currentNode = 3;
    //                turningRight = true;
    //            }
    //        }
    //    }
    //}

    bool CheckStopLine()
    {
        if (Vector3.Distance(_transform.position, nodes[0].position) < 0.025f)
        {
            if(CheckTrafficStop())
            {
                stopped = true;
            }
            if (!CheckTrafficStop() && !hasNext)
            {
                currentNode = FindNextTraffic();
                if(currentNode ==3)
                {
                    currentNode = 4;
                }
                hasNext = true;
                Debug.Log("StopLineCheck");
            }
            return true;
        }
        return false;
    }

    int FindNextTraffic()
    {
        switch (carColor)
        {
            case CarColor.Red:
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (nodes[i] != null)
                        { 
                            if (nodes[i].gameObject.GetComponent<TrafficNode>().entranceTraffic.JunctionNumber == Direction.Instance.RedTarJunc[curTraffic.JunctionNumber - 1])
                            {
                                return i;
                                
                            }
                        }
                    }

                    break;
                }
            case CarColor.Green:
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (nodes[i] != null)
                        {                           
                            if (nodes[i].gameObject.GetComponent<TrafficNode>().entranceTraffic.JunctionNumber == Direction.Instance.GreenTarJunc[curTraffic.JunctionNumber - 1])
                            {
                                return i;
                                
                            }
                        }
                    }
                    break;
                }
            case CarColor.Blue:
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (nodes[i] != null)
                        {
                            if (nodes[i].gameObject.GetComponent<TrafficNode>().entranceTraffic.JunctionNumber == Direction.Instance.BlueTarJunc[curTraffic.JunctionNumber - 1])
                            {
                                return i;
                                
                            }
                        }
                    }
                    break;
                }
            case CarColor.Orange:
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (nodes[i] != null)
                        {
                            if (nodes[i].gameObject.GetComponent<TrafficNode>().entranceTraffic.JunctionNumber == Direction.Instance.OrangeTarJunc[curTraffic.JunctionNumber - 1])
                            {
                                return  i;
                               
                            }
                        }
                    }
                    break;
                }
            case CarColor.Yellow:
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (nodes[i] != null)
                        {
                            if (nodes[i].gameObject.GetComponent<TrafficNode>().entranceTraffic.JunctionNumber == Direction.Instance.YellowTarJunc[curTraffic.JunctionNumber - 1])
                            {
                                return i;
                                
                            }
                        }
                    }
                    break;
                }
            case CarColor.Purple:
                {
                    for (int i = 1; i < 4; i++)
                    {
                        if (nodes[i] != null)
                        {
                            if (nodes[i].gameObject.GetComponent<TrafficNode>().entranceTraffic.JunctionNumber == Direction.Instance.PurpleTarJunc[curTraffic.JunctionNumber - 1])
                            {
                                return  i;
                                
                            }
                        }
                    }
                    break;
                }

            default: 
                
             return 0;

            
        }
        //if(carColor == CarColor.Red)
        //{
        //    if (nodes[2].gameObject.GetComponent<TrafficNode>().entranceTraffic.JunctionNumber == Direction.Instance.RedTarJunc[curTraffic.JunctionNumber - 1])
        //    {
        //        currentNode = 2;

        //    }
        //}
        return 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Exit"))
        {
            gameObject.SetActive(false);
        }
    }



}
