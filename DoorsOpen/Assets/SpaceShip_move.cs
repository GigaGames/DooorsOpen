using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpaceShip_move : MonoBehaviour
{
    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    public GameObject dokingStation;
    public GameObject spaceShip;
    public GameObject Shipcam;
    public GameObject spaceShipDummy;
    public GameObject FpsPlayer;
    
 
    Transform myT;


    private void Awake()
    {
        myT = transform;
    }

    private void Update()
    {
        Turn();
        Thrust();
    }

   public void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float Pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("roll");
        myT.Rotate(-Pitch, yaw, -roll);
    }

    public void Thrust()
    {
        if (Input.GetAxis("Vertical") > 0)
        {
            myT.position += myT.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ForceField")) 
        {
            Landing();
            spaceShipDummy.SetActive(true);
            Shipcam.SetActive(false);
            FpsPlayer.SetActive(true);
            spaceShip.SetActive(false);
            
            
           
        }
    }

    void Landing()
    {
        transform.position = new Vector3(dokingStation.transform.position.x, dokingStation.transform.position.y, dokingStation.transform.position.z);
    }


}
