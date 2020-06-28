using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject spaceShip;
    public GameObject DummyShip;

    public void TrunOffShip()
    {
       spaceShip.gameObject.SetActive(false);
       DummyShip.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
