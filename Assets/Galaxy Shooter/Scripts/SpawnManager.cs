using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private GameObject[] powerups;
    // Start is called before the first frame update
    private int enemyCount = 2;
    void Start()
    {
        StartCoroutine(enemySpawnRoutine());
        StartCoroutine(powerupsSpawnRoutine());
    }

    private IEnumerator enemySpawnRoutine(){
       while(enemyCount < 2){
         Instantiate(enemy,new Vector3(Random.Range(-8.3223f,8.2421f),5.5f,0),Quaternion.identity);
         enemyCount++;
        yield return new WaitForSeconds(5);
       }
    }

    private IEnumerator powerupsSpawnRoutine(){
       while(true){
         int index = Random.Range(0,2);
         Instantiate(powerups[index],new Vector3(Random.Range(-8.3223f,8.2421f),5.5f,0),Quaternion.identity);
        yield return new WaitForSeconds(10);
       }
    }

}
