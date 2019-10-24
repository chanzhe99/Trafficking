using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    public static TrafficManager Instance;
    [SerializeField] private List<TrafficLight> lights;
    [SerializeField] private List<GameObject> lightsObj;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for (int i= 0; i<lights.Count; i++)
        {
            lightsObj.Add(lights[i].gameObject);
        }
    }

    public void ShutOthers(GameObject obj)
    {
        for(int i =0; i<lights.Count; i++)
        {
            if(!ReferenceEquals(lightsObj[i], obj))
            {
                lights[i].ChangeStop();
                Debug.Log("Shut down");
            }
        }

    }


}
