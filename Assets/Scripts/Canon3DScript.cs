using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon3DScript : MonoBehaviour
{
    public GameObject PivotCanon;

    public float CanonDelayShot = 4.0f;
    public float TimerShot = 0.0f;

    public float ClampMin = -0.3f;
    public float ClampMax =  0.3f;

    public GameObject BulletPrefab;
    public GameObject BulletSpawnerPos;

    public GameObject HUD;
    public GameObject theCamera;
    public GameObject AnimSmoke;
    // Start is called before the first frame update
    void Start()
    {
        HUD = Instantiate(HUD);
        HUD.GetComponent<HUDScript>().Canon = this.gameObject;
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
            Quaternion resultLookAt = Quaternion.LookRotation(hit.point - transform.position, transform.up);
            //Debug.Log(Quaternion.LookRotation(hit.point - transform.position, transform.up));

            if (!(resultLookAt.y <= ClampMin || resultLookAt.y >= ClampMax))
            {
                PivotCanon.transform.LookAt(hit.point);
                PivotCanon.transform.eulerAngles = new Vector3(0, PivotCanon.transform.eulerAngles.y, 0);
            }
            
        }


        if (Input.GetButtonDown("Fire1") && TimerShot <= 0.0f)
        {
            Shoot();
            TimerShot += CanonDelayShot;
        }
        if (TimerShot > 0.0f)
        {
            TimerShot -= Time.deltaTime;
        }
        //transform.position = MyRay.
    }
    public void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawnerPos.transform.position, BulletSpawnerPos.transform.rotation);
        theCamera.GetComponent<CameraShake>().shakeDuration = 0.1f;
        AnimSmoke.active = true;
        Invoke("DesactiveAnim", 0.4F);
    }
    public void DesactiveAnim()
    {
        AnimSmoke.active = false;
    }
}
