
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour {

    public Transform[] target;
    [SerializeField]private int speed = 0;
    private int current = 0;
    private bool isactive = true;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip Higdie1;
    
    [SerializeField]
    AudioClip Higdie2;

    bool soundon = false;


    void Start () {
            
    }



    void Update () {
        //Debug.Log(GetComponent<Rigidbody>().velocity);
        GetComponentInChildren<Animator>().SetFloat("Horizontal", -GetComponentInChildren<Rigidbody>().velocity.x);
        GetComponentInChildren<Animator>().SetFloat("Vertical",GetComponentInChildren<Rigidbody>().velocity.z);
        if (transform.position != target[current].position && target != null && transform.position.y > 0 && isactive == true){
            Vector3 pos = Vector3.MoveTowards(transform.position,target[current].position,speed * Time.deltaTime);
            GetComponentInChildren<Rigidbody>().MovePosition(pos);
            //Debug.Log(current);
        }//else current = (current + 1) % target.Length;
        

        if(this.transform.position.y > 200 && soundon == false)
        {
            source.PlayOneShot(Higdie1);
            soundon = true;
        }
        if(this.transform.position.y > 5000 )
        {
            Destroy(this.gameObject);
            //SceneManager.LoadScene(0);
        }
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.tag == "target" && tag == "Enemy" ){
          
            if(current+1 < target.Length)
            {
                Debug.Log(current);
                current += 1;
            }
        }
        if (other.tag == "bullet")
        {
            //Debug.Log(current);
            //Spawner.EnemyCount -= 1;
            //Destroy(this.gameObject);
        }
    }

    public void setPatrols(Transform[] tabtarg)
    {
        target = tabtarg;
    }

    public void StopPatrol()
    {
        isactive = false;
    }
}
