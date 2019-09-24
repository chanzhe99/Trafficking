using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitEntrance : MonoBehaviour
{
    public GameObject Exit1;
    public GameObject Exit2;
    //public GameObject Entrance1;
    //public GameObject Entrance2;

    bool isExit1 = false;
    bool isExit2 = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.ReferenceEquals(gameObject, Exit1))
        {
            isExit1 = true;
        }
        else if (GameObject.ReferenceEquals(gameObject, Exit2))
        {
            isExit2 = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider oth)
    {
        if(isExit1)
        {
            
            CarAttribute tempCar = new CarAttribute(oth.gameObject, Time.time + 5f);
            InterjunctionTravel.Instance.Exit1.Add(tempCar);
            oth.gameObject.SetActive(false);
        }
        else if(isExit2)
        {
      
            CarAttribute tempCar = new CarAttribute(oth.gameObject, Time.time + 5f);
            InterjunctionTravel.Instance.Exit2.Add(tempCar);
            oth.gameObject.SetActive(false);
        }
    }
}
