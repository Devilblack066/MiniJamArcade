using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] target;



    [SerializeField] public GameObject PrefabEnemy;

    [SerializeField] public int InitialSpoolCount;

    [SerializeField] public int spawnTime;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<InitialSpoolCount;i++){
        Invoke("Spawn", spawnTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void Spawn ()
    {

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject EnnemySPWND = Instantiate (PrefabEnemy,this.transform.position ,this.transform.rotation);
        EnnemySPWND.GetComponent<Patrol>().setPatrols(target);
   
    }
}
