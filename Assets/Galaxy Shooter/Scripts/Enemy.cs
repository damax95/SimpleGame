using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3.0f;
    [SerializeField]
    private GameObject enemyExplosion;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-8.3223f,8.2421f),5.5f,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down*speed*Time.deltaTime);
        if(transform.position.y < -5.5f){
            resetPos();
        }
        
    }

    void OnTriggerEnter2D(Collider2D obj){
        Debug.Log(obj.tag);
        switch(obj.tag){
            case "Laser":
            Laser laser = obj.GetComponent<Laser>();
            if(laser != null) laser.die();
            Instantiate(enemyExplosion,transform.position,Quaternion.identity);
            resetPos();
            break;

            case "Player":
            Player player = obj.GetComponent<Player>();
            if(player != null) player.die(1.0f);
            Instantiate(enemyExplosion,transform.position,Quaternion.identity);
            resetPos();
            break;
        }
    }

    private void resetPos(){
        float x = Random.Range(-8.3223f,8.2421f);
        transform.position = new Vector3(x,5.5f,0);
    }


}
