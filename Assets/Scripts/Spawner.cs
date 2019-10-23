﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{

    public Transform[] target;



    [SerializeField] public GameObject PrefabEnemy;

    [SerializeField] public int InitialSpoolCount = 10;

    [SerializeField] public float spawnTime = 1.0f;

    private List<GameObject> TabEnemySpawn;
    private Coroutine theCoroutine;
    private int nbspawn = 0;


    // Start is called before the first frame update
    void Start()
    {
        theCoroutine = StartCoroutine(Spawn());
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

    public IEnumerator Spawn()
    {
        while (true)
        {
            ++nbspawn;
            //Debug.Log(nbspawn);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            GameObject EnnemySPWND = Instantiate(PrefabEnemy, this.transform.position, this.transform.rotation);
            EnnemySPWND.GetComponent<Patrol>().setPatrols(target);
            //TabEnemySpawn.Add(EnnemySPWND);
            if (nbspawn == InitialSpoolCount)
            {
                //Debug.Log("?");
                StopCoroutine(theCoroutine);
            }
            yield return new WaitForSeconds(1.0f);
        }
    }
}
