using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    public static Direction Instance;

    public int[] RedTarJunc;
    public int[] GreenTarJunc;
    public int[] BlueTarJunc;
    public int[] OrangeTarJunc;
    public int[] YellowTarJunc;
    public int[] PurpleTarJunc;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
