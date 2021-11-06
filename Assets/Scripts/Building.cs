using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{


    public int countInput = 0;

    public Resources resource;

    public Resources[] input = new Resources[2];
    
    void Start()
    {
        resource = (Resources)Random.Range(0, 1);
        if (Resources.Bread == resource)
        {
            input[0] = Resources.Hank;
        }
    }

    
    void Update()
    {
        if (countInput)
    }
}
