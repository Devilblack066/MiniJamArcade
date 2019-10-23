﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    public float AccelerationProjectile = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(transform.position);
        transform.position = transform.position + (transform.forward*AccelerationProjectile);

    }


    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            //Debug.Log(other.GetComponent<Rigidbody>());
            other.GetComponent<Patrol>().StopPatrol();
            other.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x*10000, other.transform.up.y * 10000, transform.forward.z * 10000);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        /*Debug.Log("Coucou");
        if (collision.transform.GetComponent<Rigidbody2D>())
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.up.x, transform.up.y));
        }
    }*/
}
