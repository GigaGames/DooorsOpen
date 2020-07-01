using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutogunFire : MonoBehaviour
{
    public GameObject lookpoint;
    public AutoGunScript AutoGunScript;
    public Transform firePoints;
   // public GameObject BulletPrefab;
    public GameObject MussleFlash;
    public float damage = 10f;

    public float fireRate = 10f;
    bool range;

    private float nextTimeTOFire = 0f;
    public float impactForce = 3f;

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        range = AutoGunScript.inSight;
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        if (range)
        {
            if (Time.time >= nextTimeTOFire)
            {
                Fire();
            }
            Debug.Log("inrange");
        }
        

    }

    public void Fire()
    {
        nextTimeTOFire = Time.time + 10f / fireRate;

        Ray ray = new Ray(lookpoint.transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
          
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
            Debug.Log(hitInfo.transform.tag);

            playerHealth Phealth = hitInfo.transform.GetComponent<playerHealth>();

            if (Phealth != null)
            {
                Phealth.TakeDamage(damage);
            }

            if (hitInfo.rigidbody != null)
            {

                hitInfo.rigidbody.AddForce(-hitInfo.normal * impactForce);

            }
            GameObject impact = Instantiate(MussleFlash, firePoints.position, Quaternion.LookRotation(firePoints.forward));

            Destroy(impact, 1f);
        }
    }
}
