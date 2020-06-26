using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fanController : MonoBehaviour
{
    public float fanSpeed = 2f;
    public GameObject fanBlade;

    

    // Update is called once per frame
    void Update()
    {
       fanBlade.transform.Rotate(0, fanSpeed * Time.deltaTime, 0);
    }
}
