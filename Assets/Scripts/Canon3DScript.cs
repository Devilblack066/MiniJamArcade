using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon3DScript : MonoBehaviour
{
    public GameObject PivotCanon;

    public float CanonDelayShot = 4.0f;
    public float TimerShot = 0.0f;

    public GameObject BulletPrefab;
    public GameObject BulletSpawnerPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray MyRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        /*if (Physics.Raycast(MyRay, out hit))
        {
            hit.collider.renderer.material.color = Color.red;
            //Debug.Log(hit);
        }*/
        RaycastHit hit;
        if (Physics.Raycast(MyRay, out hit))
        {
            /*hit.collider.GetComponent<Renderer>().material.color = Color.red;*/
            //Debug.Log(hit.point);
            PivotCanon.transform.LookAt(hit.point);
            PivotCanon.transform.eulerAngles = new Vector3(0, PivotCanon.transform.eulerAngles.y, 0);
        }


        if (Input.GetButtonDown("Fire1") && TimerShot <= 0.0f)
        {
            GameObject bullet = Instantiate(BulletPrefab, BulletSpawnerPos.transform.position, BulletSpawnerPos.transform.rotation);
            TimerShot += CanonDelayShot;
        }
        if (TimerShot > 0.0f)
        {
            TimerShot -= Time.deltaTime;
        }
        //transform.position = MyRay.
    }
}
