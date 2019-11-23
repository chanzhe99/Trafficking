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
    bool turning = false;


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


    public void ResetValues()
    {
        for(int i=0; i < nodes.Length; i++)
        {
            nodes[i] = null;
        }
        currentNode = 0;
        curTraffic = null;
        turningRight = false;
        hasNext = false;
        patience = 10f;
        stopped = false;
        increasingP = false;
        decreasingP = false;
        decreasingS = false;
        turnNo = 0;
        turning = false;
        relativePos = Vector3.zero;
        targetRot = Quaternion.identity;
        target = null;
        startRot = Quaternion.identity;
        self = Quaternion.identity;
        startPos = null;
        endPos = null;
        startTime = 0.0f;
        journeyTime = 0.0f;
        centerPoint = Vector3.zero;
        startRelCenter = Vector3.zero;
        endRelCenter = Vector3.zero;
    }

    private void Awake()
    {
        nodes = new Transform[5];
    }
    private void Start()
    {
        signalLights = GetComponent<TurnLights>();        
        self = transform.rotation;
        currentNode = 0;
        if (curTraffic != null)
            InitNodes();
    }

    private void Update()
    {
        GetTurnSignal();
        GetNodes();
        if (!CheckToStop() )
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
           
            if(curTraffic.canStraightTurn || currentNode != 0)
            {
                if(currentNode == 1 )
                {
                    Drive();
                }
            }
            if(curTraffic.canRightTurn || currentNode != 0)
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
            if(curTraffic.canLeftTurn || currentNode != 0)
            {
                if(currentNode == 2)
                {
                    Turn();
                }
            }
           
            if (!turningRight && currentNode == 4)
            {
                if (Vector3.Distance(transform.position, nodes[currentNode].position) < 0.01f)
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
        if (patience < 1)
        {
            ScoreManager.instance.ImpatientCarOnScreen();
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
        }
        yield return new WaitForSeconds(1.0f);
        decreasingP = false;
    }

    private IEnumerator IncreasePatience()
    {
        if (patience < 11)
        {
            patience += 1f;
        }
        yield return new WaitForSeconds(1.0f);
        increasingP = false;
    }

    void Turn()
    {
        turning = true;
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
            self = transform.rotation;
            startRot = transform.rotation; 
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
            Vector3 direct = (transform.TransformDirection(Vector3.right).normalized);
            GetCenter(direct);
        }
        else
        {
            Vector3 direct = (transform.TransformDirection(Vector3.left).normalized);
            GetCenter(direct);
        }
        
        float fracComplete = (Time.time - startTime) / GetJourneyTime(startPos, endPos) ;
        transform.position = Vector3.Slerp(startRelCenter, endRelCenter, fracComplete);
        transform.rotation = Quaternion.Lerp(startRot, targetRot, fracComplete);
        transform.position += centerPoint;
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
        turning = false;
        stopped = false;
        startTime = 0.0f;
        turningRight = false;
        transform.position = Vector3.MoveTowards(transform.position, nodes[currentNode].position, Time.deltaTime * carSpeed);
    }


    private bool CheckToStop()
    {
        float rayRange;
        if(turning)
        {
            rayRange = 1.5f;
        }
        else
        {
            rayRange = 2.3f;
        }

        RaycastHit hit;
        Vector3 direct = (transform.TransformDirection(new Vector3(0, 0, 1)).normalized);
        Debug.DrawRay(transform.position, direct * rayRange, Color.red);
        if (Physics.Raycast(transform.position, direct, out hit, rayRange, layer))
        {
            if (hit.transform.gameObject.CompareTag("Car"))
            {
                stopped = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
        
        
    }

    void GetNodes()
    {
        if(currentNode == 1 || currentNode == 2 || currentNode == 3)
        {
            if(Vector3.Distance(transform.position, nodes[currentNode].position) < 0.025f)
            {
                Debug.Log("Getting node");
                Debug.Log(currentNode);
                hasNext = false;
                curTraffic = nodes[currentNode].gameObject.GetComponent<TrafficNode>().entranceTraffic;
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
            }
        }
    }

    public void InitNodes()
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
        currentNode = 0;
    }

    bool CheckTrafficStop()
    {
        if(FindNextTraffic() == 1 && curTraffic.canStraightTurn)
        {
            return false;
        }
        else if(FindNextTraffic() == 2 && curTraffic.canLeftTurn)
        {
            return false;
        }
        else if((FindNextTraffic() == 3 || FindNextTraffic() == 4) && curTraffic.canRightTurn)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    void GetTurnSignal()
    {
        turnNo = 0;
        if(curTraffic.JunctionNumber>10)
        {
            return;
        }
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

    bool CheckStopLine()
    {
        if (Vector3.Distance(transform.position, nodes[0].position) < 0.025f)
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
        if (other.gameObject.CompareTag("Exit"))
        {
            gameObject.SetActive(false);
            Score.Instance.carCounter++;
            //Destroy(other.gameObject);
            ScoreManager.instance.AdjustMultiplier();
            if (patience > 0)
            {
                ScoreManager.instance.AddToScore();
            }
        }
        ScoreManager.instance.ImpatientCarLeavesScreen();
    }
}
