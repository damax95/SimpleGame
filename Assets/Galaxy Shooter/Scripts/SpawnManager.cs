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
    void Start()
    {
        StartCoroutine(enemySpawnRoutine());
        StartCoroutine(powerupsSpawnRoutine());
    }

    private IEnumerator enemySpawnRoutine(){
       while(true){
         Instantiate(enemy,new Vector3(Random.Range(-8.3223f,8.2421f),5.5f,0),Quaternion.identity);
        yield return new WaitForSeconds(3);
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
