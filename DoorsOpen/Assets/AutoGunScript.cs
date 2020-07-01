using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGunScript : MonoBehaviour
{
    public float lookRadius = 5f;
    public Transform player;
    public bool inSight = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float distace = Vector3.Distance(player.position, transform.position);
        Vector3 targetPostion = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        if (distace <= lookRadius)
        {
            transform.LookAt(targetPostion);
            inSight = true;
            
        }
        else
        {
            inSight = false;
        }


    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}

