using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    public GameObject bulletPrefabs;
    // Update is called once per frame
    public float interval;
    public Transform firingPoint;
    private float lastShot;
    void Update()
    {
        if(Input.GetMouseButton(0) && Time.time - lastShot >= interval){
            Instantiate(bulletPrefabs,firingPoint.position,firingPoint.rotation);
            lastShot = Time.time;
        }
    }
}
