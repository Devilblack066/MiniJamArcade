using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonScript : MonoBehaviour
{
    [SerializeField]
    public GameObject[] ListPoints;

    [SerializeField]
    public GameObject MainCanvas;

    [SerializeField]
    public GameObject TheCanon;

    [SerializeField]
    public GameObject BulletSpawnerPos;

    [SerializeField]
    public GameObject BulletPrefab;

    public GameObject AnimSmoke;

    [SerializeField]
    public float CanonDelayShot = 5.0f;

    public float TimerShot = 0.0f;

    float isMoving = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float myFloat= Input.mousePosition.x/Screen.currentResolution.width;
        //Screen.currentResolution;

       // Debug.Log(myFloat);
        TheCanon.transform.position = QuadraticCurve(
            new Vector2(ListPoints[0].transform.position.x, ListPoints[0].transform.position.y),
            new Vector2(ListPoints[1].transform.position.x, ListPoints[1].transform.position.y),
            new Vector2(ListPoints[2].transform.position.x, ListPoints[2].transform.position.y),
            myFloat+0.2f);
        TheCanon.transform.localRotation = new Quaternion();

        if (Input.GetButtonDown("Fire1") && TimerShot<=0.0f)
        {
            GameObject bullet = Instantiate(BulletPrefab, BulletSpawnerPos.transform.position, BulletSpawnerPos.transform.rotation, MainCanvas.transform);
            TimerShot += CanonDelayShot;
        }
        if (TimerShot > 0.0f)
        {
            TimerShot -= Time.deltaTime;
        }
    }

    public Vector2 Lerp(Vector2 a, Vector2 b, float floatValue)
    {
        return a + (b - a) * floatValue;
    }

    public Vector2 QuadraticCurve(Vector2 a, Vector2 b, Vector2 c, float floatValue)
    {
        Vector2 p0 = Lerp(a, b, floatValue);
        Vector2 p1 = Lerp(b, c, floatValue);
        return Lerp(p0, p1, floatValue);
    }
}
