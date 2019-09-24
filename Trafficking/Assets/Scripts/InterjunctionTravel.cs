using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CarAttribute
{
    public GameObject obj;
    public float ShouldExitTime = -1f;
    public CarAttribute(GameObject car, float exitTime)
    {
        obj = car;
        ShouldExitTime = exitTime;
    }
}

public class InterjunctionTravel : MonoBehaviour
{
    public static InterjunctionTravel Instance;

    public GameObject Entrance2;
    public GameObject Entrance3;

    public List<CarAttribute> Exit1;
    public List<CarAttribute> Exit2;

    public Transform _entrance2Trans;
    public Transform _entrance3Trans;
    


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _entrance2Trans = Entrance2.transform;
        _entrance3Trans = Entrance3.transform;
    }

    void Update()
    {
        CheckToExit1();
        CheckToExit2();
       
    }

    public void CheckToExit1()
    {
        if (Exit1.Count > 0)
        {
            if (Exit1[0].obj != null && Exit1[0].ShouldExitTime != -1f)
            {
                if (Time.time > Exit1[0].ShouldExitTime)
                {
                    Exit1[0].obj.transform.position = _entrance2Trans.position;
                    Exit1[0].obj.SetActive(true);
                    Exit1.RemoveAt(0);

                }
            }
        }
    }

    public void CheckToExit2()
    {
        if (Exit2.Count > 0)
        {
            if (Exit2[0].obj != null && Exit2[0].ShouldExitTime != -1f)
            {
                if (Time.time > Exit2[0].ShouldExitTime)
                {
                    Exit2[0].obj.transform.position = _entrance3Trans.position;
                    Exit2[0].obj.SetActive(true);
                    Exit2.RemoveAt(0);

                }
            }
        }
    }
}
