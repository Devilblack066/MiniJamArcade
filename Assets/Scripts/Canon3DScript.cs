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
    [SerializeField]
    public AudioSource sourceShot;
    [SerializeField]
    public AudioSource sourceRail;

    [SerializeField]
    public AudioClip BoomCanon;

    [SerializeField]
    public AudioClip ReloadCanonSFX;

    public GameObject SparksRight;
    public GameObject SparksLeft;

    public GameObject Aimer;

    public Animator AnimCanon;

    void Start()
    {

        HUD = Instantiate(HUD);
        HUD.GetComponent<HUDScript>().Canon = this.gameObject;
        //AnimCanon.SetFloat("Blend",0.0f);
        AnimCanon.SetBool("Shoot", false);
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
        Aimer.transform.position = hit.point;
        if (Input.GetAxis("Mouse X") > 0.2)
        {
            sourceRail.mute = false;
            SparksLeft.active = true;
            SparksRight.active = false;
        }
        else if (Input.GetAxis("Mouse X") < -0.2)
        {
            sourceRail.mute = false;
            SparksLeft.active = false;
            SparksRight.active = true;
        }
        else
        {
            sourceRail.mute = true;
            SparksLeft.active = false;
            SparksRight.active = false;
        }

        if (Input.GetButtonDown("Fire1") && TimerShot <= 0.0f)
        {
            ActiveShoot();
            TimerShot += CanonDelayShot;
            
        }
        if (TimerShot > 0.0f)
        {
            TimerShot -= Time.deltaTime;
        }
        //transform.position = MyRay.
    }
    public void ActiveShoot()
    {
        AnimCanon.SetBool("Shoot", true);
        Invoke("Shoot", 0.4f);
        Invoke("DesactiveAnimCanon", 0.6f);
        //AnimCanon.SetBool("Shoot", false);
    }
    public void Shoot()
    {
        sourceShot.PlayOneShot(BoomCanon);
        GameObject bullet = Instantiate(BulletPrefab, BulletSpawnerPos.transform.position, BulletSpawnerPos.transform.rotation);
        theCamera.GetComponent<CameraShake>().shakeDuration = 0.1f;
        AnimSmoke.active = true;
        sourceShot.PlayOneShot(ReloadCanonSFX);
        Invoke("DesactiveAnim", 0.4f);
    }
        public void DesactiveAnim()
    {
        AnimSmoke.active = false;
    }
    public void DesactiveAnimCanon()
    {
        AnimCanon.SetBool("Shoot", false);
    }
}
