using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnnemyCount : MonoBehaviour
{
    // Start is called before the first frame update

    public static int NbEnemy = 0;
    void Start()
    {
    }



    // Update is called once per frame
    void Update()
    {
        
    }



    public static IEnumerator CheckWin()
    {
        while (true)
        {
            //Debug.Log(EnemyCount);
            if (EnnemyCount.NbEnemy == 0 )
            {
                //SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadScene(2);
                //SceneManager.UnloadSceneAsync();
            }
            yield return new WaitForSeconds(0.1f);
        }

    }
}
