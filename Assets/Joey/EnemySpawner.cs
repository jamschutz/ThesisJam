using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnLocations;
    public Vector2 tearConstraints;
    public float tearSpeed;
    public float spawnRate;
    public bool symmetricalSpawn;
    public Vector2 tearDirectionConstraints;


    float timer;

    void Start()
    {
        timer = 0;
    }


    void Update()
    {
        if(timer >= spawnRate) {
            // spawn tear
            if(symmetricalSpawn) {
                float xPos = Random.Range(0, tearConstraints.y);
                Vector3 rightPos = new Vector3(xPos, transform.position.y, 0);
                Vector3 leftPos = new Vector3(-xPos, transform.position.y, 0);
                var leftTear = GameObject.Instantiate(enemyPrefab, leftPos, Quaternion.identity);
                var rightTear = GameObject.Instantiate(enemyPrefab, rightPos, Quaternion.identity);
                leftTear.GetComponent<TearController>().moveSpeed = tearSpeed;
                rightTear.GetComponent<TearController>().moveSpeed = tearSpeed;
            }
            else {
                int spawnLocationIndex = Random.Range(0, spawnLocations.Length);
                // Vector3 spawnPosition = new Vector3(
                //     Random.Range(tearConstraints.x, tearConstraints.y),
                //     transform.position.y,
                //     0
                // );
                Vector3 spawnPosition = spawnLocations[spawnLocationIndex].position;
                var tear = GameObject.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                tear.GetComponent<TearController>().moveSpeed = tearSpeed;
                tear.transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}