using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnLocations;
    public Vector2 tearConstraints;
    public Vector2 tearSpeed;
    public Vector2 tearSpeedHorizontal;
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
                // leftTear.GetComponent<TearController>().moveSpeed = tearSpeed;
                // rightTear.GetComponent<TearController>().moveSpeed = tearSpeed;
            }
            else {
                int spawnLocationIndex = Random.Range(0, spawnLocations.Length);
                Vector3 spawnPosition = spawnLocations[spawnLocationIndex].position;
                float tearMoveWidth = Random.Range(tearDirectionConstraints.x, tearDirectionConstraints.y);
                Vector2 tearMoveConstraints = new Vector2(spawnPosition.x - tearMoveWidth, spawnPosition.y + tearMoveWidth);

                var tear = GameObject.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                tear.GetComponent<TearController>().moveSpeed = Random.Range(tearSpeed.x, tearSpeed.y);
                float horizontalMove = Random.Range(tearSpeedHorizontal.x, tearSpeedHorizontal.y);
                tear.GetComponent<TearController>().horizontalMoveSpeed = (Random.Range(0, 10) <= 5)? horizontalMove : -horizontalMove;
                tear.GetComponent<TearController>().moveConstraints = tearMoveConstraints;
            }
            
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
