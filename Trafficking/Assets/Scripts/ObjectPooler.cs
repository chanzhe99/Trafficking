using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{
    public int amountToPool;
    public GameObject objectToPool;
    public bool usedInScene = false;
}

public class ObjectPooler : MonoBehaviour
{

    //Testing
  

    
    public static ObjectPooler Instance;
    public List<ObjectPoolItem> itemsToPool;
    public List<GameObject> pooledObjects;
    // Start is called before the first frame update
    void Awake()
    {
        if(Instance == null)
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
        //Example
        

        pooledObjects = new List<GameObject>();
        foreach(ObjectPoolItem item in itemsToPool)
        {
            for(int i=0; i<item.amountToPool; i++)
            {
                GameObject obj = (GameObject)Instantiate(item.objectToPool);
                obj.SetActive(false);
                pooledObjects.Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(string tag)
    {
        for(int i =0; i<pooledObjects.Count; i++)
        {
            if(!pooledObjects[i].activeInHierarchy && pooledObjects[i].CompareTag(tag))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }

    public GameObject GetSpecificObject(GameObject toBeCompared)
    {
        for(int i=0; i<pooledObjects.Count; i++)
        {
            if(GameObject.ReferenceEquals(pooledObjects[i], toBeCompared))
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
