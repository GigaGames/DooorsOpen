using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunhealth : MonoBehaviour
{
    public float Health = 100f;


    public void TakeDamage(float amount)
    {
        Health -= amount;
        if (Health <= 0f)
        {
            Die();
            Debug.Log("Gun bussted");

        }
    }


    public void Die()
    {
        Destroy(gameObject);

    }
}
