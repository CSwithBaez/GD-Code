using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    float minSpeed = 12;
    float maxTorque = 10;
    float ySpawnPos = -6;
    float maxSpeed = 16;
    float xRange = 4;
    private Rigidbody targetRB;
    private GameBoss gameManager;
    public int pointValue;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameBoss>();
        targetRB = GetComponent<Rigidbody>();
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);
        targetRB.AddTorque(RandomTorque(),RandomTorque(),
                 RandomTorque(),ForceMode.Impulse);
        
        //transform.position = new Vector3(Random.Range(-4,4),-6);
        transform.position = (RandomSpawnPosition());
    }

    Vector3  RandomForce(){
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque() { 
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPosition(){
        return new Vector3(Random.Range(-xRange,  xRange),ySpawnPos);
    }

    void OnMouseDown()
    {
        if(gameManager.isGameActive){
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position,
            explosionParticle.transform.rotation);
            //put the bad tag on the object you to trigger go
            //Better use would be a timer
            if (gameObject.CompareTag("enemy"))
            {
                gameManager.GameOver();
            }
        }
    }
    void OnTriggerEnter(Collider other) {
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
