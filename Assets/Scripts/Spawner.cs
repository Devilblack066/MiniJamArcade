using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public Transform[] target;



    [SerializeField] public GameObject PrefabEnemy;
    [SerializeField] public GameObject PrefabEnemyFaster;

    [SerializeField] public int InitialSpoolCount = 0;
    [SerializeField] public int InitialSpoolCountFaster = 1;

    [SerializeField] public float spawnTime = 1.0f;
    [SerializeField] public float spawnTimeFaster = 5.0f;

    private List<GameObject> TabEnemySpawn;
    private Coroutine theCoroutine = null;
    private Coroutine theCoroutineFaster = null;
    private int nbspawn = 0;
    private int nbspawnfaster = 0;

    public static int EnemyCount;


    // Start is called before the first frame update
    void Start()
    {
        if(InitialSpoolCount > 0)theCoroutine = StartCoroutine(SpawnNormal());
        if(InitialSpoolCountFaster > 0)theCoroutineFaster = StartCoroutine(SpawnFaster());
        //StartCoroutine(EzWin());
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

    public IEnumerator CheckWin()
    {
        while(true)
        {
            if(EnemyCount == 0 )
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(0);
                //SceneManager.UnloadSceneAsync();
            }
            yield return new WaitForSeconds(0.1f);
        }

    }

    public IEnumerator SpawnNormal()
    {
        while (true)
        {
            //TabEnemySpawn.Add(EnnemySPWND);
            if (nbspawn < InitialSpoolCount)
            {
                ++nbspawn;
                //Debug.Log(nbspawn);
                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                GameObject EnnemySPWND = Instantiate(PrefabEnemy, this.transform.position, this.transform.rotation);
                EnnemySPWND.GetComponent<Patrol>().setPatrols(target);
                ++EnemyCount;
            }
            else
            {
                //Debug.Log("?");
                /*if(theCoroutine != null)*/
                if (theCoroutineFaster == null) StartCoroutine(CheckWin());
                StopCoroutine(theCoroutine);
                theCoroutine = null;
            }
            yield return new WaitForSeconds(spawnTime);
        }
    }

    public IEnumerator SpawnFaster()
    {
        while (true)
        {  
            //TabEnemySpawn.Add(EnnemySPWND);
            if (nbspawnfaster < InitialSpoolCountFaster)
            {
                ++nbspawnfaster;
                //Debug.Log(nbspawn);
                // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
                GameObject EnnemySPWND = Instantiate(PrefabEnemyFaster, this.transform.position, this.transform.rotation);
                Transform[] newtab = { target[0], target[target.Length - 1] };
                EnnemySPWND.GetComponent<Patrol>().setPatrols(newtab);
                ++EnemyCount;
            }
            else
            {
                //Debug.Log("?");
                /*if(theCoroutine != null)*/
                if (theCoroutine == null) StartCoroutine(CheckWin());
                StopCoroutine(theCoroutineFaster);
                theCoroutineFaster = null;
            }
            yield return new WaitForSeconds(spawnTimeFaster);
        }
    }
}
