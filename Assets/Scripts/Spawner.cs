using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public Transform[] target;



    [SerializeField] public GameObject PrefabEnemy;

    [SerializeField] public int InitialSpoolCount;

    [SerializeField] public int spawnTime;

    private List<GameObject> TabEnemySpawn;
    private bool spawnend = false;


    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<InitialSpoolCount;i++){
        Invoke("Spawn", spawnTime);

        }
        spawnend = true;
    }

    // Update is called once per frame
    void Update()
    {
       /* if(spawnend && TabEnemySpawn != null)
        {
            bool isthereenemy = false;
            foreach (GameObject go in TabEnemySpawn)
            {
                if(go != null)
                {
                    isthereenemy = true;
                    break;
                }
            }
            if(isthereenemy == false)
            {
                SceneManager.LoadScene(0);
            }
        }*/
    }

        void Spawn ()
    {

        // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
        GameObject EnnemySPWND = Instantiate (PrefabEnemy,this.transform.position ,this.transform.rotation);
        EnnemySPWND.GetComponent<Patrol>().setPatrols(target);
        TabEnemySpawn.Add(EnnemySPWND);
   
    }
}
