using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject bullet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        //shooting logic
        Instantiate(bullet, FirePoint.position, FirePoint.rotation);
    }
}
