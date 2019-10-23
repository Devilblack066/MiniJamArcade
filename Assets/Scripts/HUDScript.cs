using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HUDScript : MonoBehaviour
{
    public GameObject Canon;
    private Canon3DScript CanonCD;

    // Start is called before the first frame update
    void Start()
    {
        CanonCD = Canon.GetComponent<Canon3DScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //CanonCD = Canon.GetComponent<Canon3DScript>().T;
        GetComponentInChildren<Image>().fillAmount = CanonCD.TimerShot / CanonCD.CanonDelayShot;
    }
}
