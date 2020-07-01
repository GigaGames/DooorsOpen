using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lasergunFire : MonoBehaviour
{
    public float shootRate;
    private float m_shootRateTimeStamp;
    public AutoGunScript AutoGunScript;
    public GameObject lookpoint;
    public GameObject m_shotPrefab;
    public Transform player;
    public Transform[] LaserShoters;
    public float damage = 10f;
    public float impactForce = 4f;
    bool inrange;

   // RaycastHit hit;
    float range = 1000.0f;


    void Update()
    {
        inrange = AutoGunScript.inSight;


    }

    private void FixedUpdate()
    {
        if (inrange)
        {
            if (Time.time > m_shootRateTimeStamp)
            {
                shootRay();

            }
        }
    }

    void shootRay()
    {
        m_shootRateTimeStamp = Time.time + shootRate;

        Transform Ls = LaserShoters[Random.Range(0, LaserShoters.Length)];

        Ray ray = new Ray(lookpoint.transform.position, transform.forward);
        RaycastHit hitinfo;
        if (Physics.Raycast(ray, out hitinfo, range))
        {
            Debug.DrawLine(ray.origin, hitinfo.point, Color.red);
            GameObject laser = GameObject.Instantiate(m_shotPrefab, Ls.transform.position, this.transform.rotation) as GameObject;
            laser.GetComponent<ShotBehavior>().setTarget(hitinfo.point);
            GameObject.Destroy(laser, 1f);
            playerHealth Phealth = hitinfo.transform.GetComponent<playerHealth>();

            if (Phealth != null)
            {
                Phealth.TakeDamage(damage);
            }

            if (hitinfo.rigidbody != null)
            {

                hitinfo.rigidbody.AddForce(-hitinfo.normal * impactForce);

            }

        }

    }


}
