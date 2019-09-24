using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempMoveScript : MonoBehaviour
{
    public bool inTravel = false;
    private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        _transform = transform;   
    }

    // Update is called once per frame
    void Update()
    {
        _transform.Translate(-0.1f, 0, 0);
    }
}
