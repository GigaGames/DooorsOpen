using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    public float Health = 100f;


    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0f)
        {
            // Die();
            Debug.Log("die");
           
        }
    }


    public void Die()
    {
        Destroy(gameObject);

    }
}
