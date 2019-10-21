using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField]
    public int AccelerationProjectile = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (transform.up*AccelerationProjectile);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Coucou");
        if (collision.transform.GetComponent<Rigidbody2D>())
        {
            collision.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.up.x, transform.up.y));
        }
    }
}
