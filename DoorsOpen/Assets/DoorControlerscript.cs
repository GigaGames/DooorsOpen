using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DoorControlerscript : MonoBehaviour
{
    public float nearTodoor = 2f;
    public Transform player;
    public Animator Animator;
    public AudioSource doorSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (distance <= nearTodoor)
        {
            Animator.SetBool("character_nearby", true);
        }
        else
        {
            Animator.SetBool("character_nearby", false);
            doorSound.Play();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, nearTodoor);

    }
}
