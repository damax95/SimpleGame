using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool canTripleShot = false;
    private bool canSpeedUp = false;

    private float[] bounds = new float[4]{8.2421f,-8.3223f,0,-4.2f};
    private float fireRate = 0.25f;
    private float canFire = 0.0f;
    private float PowerupTime = 10.0f;
    private float lifes = 1.0f;
    private bool shielded = false;
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject shield;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    public GameObject laser3Prefab;
    // Start is called before the first frame update
    void Start()
    {
        //laserPrefab = GameObject.FindGameObjectWithTag("Laser");
        transform.position = new Vector2(0,-7);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        moveCraft(x,y);
    
    shoot();
        
    }

    void shoot(){
         if(Input.GetKeyDown(KeyCode.Space)){
        if(Time.time > canFire){
            if(canTripleShot){
            Instantiate(laser3Prefab,transform.position,Quaternion.identity);
            }else{
            Instantiate(laserPrefab,transform.position+new Vector3(0,0.85f,0),Quaternion.identity);
            }
            canFire = Time.time+fireRate;
        }
         }
    }

    private void moveCraft(float x,float y){
        if(canSpeedUp){
            speed = 10.0f;
        }else{
            speed = 5.0f;
        }
        transform.Translate(Vector2.right*Time.deltaTime*speed*x);
        transform.Translate(Vector2.up*Time.deltaTime*speed*y);
        keepBounds(bounds[0],bounds[1],bounds[2],bounds[3]);
      
    }

    private void keepBounds(float maxX,float minX,float maxY,float minY){
        // Y Axis
        if(transform.position.y > maxY){
            transform.position = new Vector2(transform.position.x,0);
        }else if(transform.position.y < minY){
             transform.position = new Vector2(transform.position.x,minY);
        }

        // X Axis
        if(transform.position.x > maxX){
            transform.position = new Vector2(maxX,transform.position.y);
        }else if(transform.position.x < minX){
             transform.position = new Vector2(minX,transform.position.y);
        }

    }

    public void tripleShotActivate(){
        canTripleShot = true;
        StartCoroutine(tripleShotPowerDownRoutine());
    }

     public void speedUpActivate(){
        canSpeedUp = true;
        StartCoroutine(speedDownRoutine());
    }
    private IEnumerator tripleShotPowerDownRoutine(){
        yield return new WaitForSeconds(PowerupTime);
        canTripleShot = false;
    }

    private IEnumerator speedDownRoutine(){
        yield return new WaitForSeconds(PowerupTime);
        canSpeedUp = false;
    }

    public void addLife(){
        if(lifes < 3.0f){
            lifes = lifes++;
        }
    }

    public void shieldActivate(){
        shielded = true;
        shield.SetActive(true);
    }

    public void die(float damage){
        if(!shielded){
            if(lifes - damage < 1.0f){
            Instantiate(explosion,transform.position,Quaternion.identity);
            Destroy(this.gameObject);
        }else{
            lifes = lifes - damage;
            Debug.Log("Lifes: "+lifes);
        }
        }else{
            shielded = false;
            shield.SetActive(false);
        }
    }

   
}
