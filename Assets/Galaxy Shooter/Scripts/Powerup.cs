using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float speed = 2.0f;
    [SerializeField]

    void Update()
    {
        transform.Translate(Vector3.down*Time.deltaTime*speed);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
       if(obj.tag == "Player"){
        Player player = obj.GetComponent<Player>();
        if(player != null){
            switch(this.gameObject.tag){
                case "TripleShot":
                player.tripleShotActivate();
                break;
                case "SpeedUp":
                player.speedUpActivate();
                break;
                case "Shield":
                player.shieldActivate();
                break;
            }
        }
        
        Destroy(this.gameObject);
       }
    }
}
