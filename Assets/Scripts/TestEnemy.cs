using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag =="bullet")
        {
            //Debug.Log("Yah");
            GetComponent<Rigidbody>().velocity=new Vector3(1,5000,1);
        }
    }
}
