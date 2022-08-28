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
    public Transform player;

    public float maxInwardDirection = -6;
    public float maxPlayerPosForDirectionChange;

    float timer;
    float startingPlayerPos;
    float startingHorizontal;

    void Start()
    {
        timer = 0;
        startingPlayerPos = player.position.y;
        startingHorizontal = tearSpeedHorizontal.x;
    }


    void Update()
    {
        if(timer >= spawnRate) {
            // spawn tear
            if(symmetricalSpawn) {
                float xPos = Random.Range(0, tearConstraints.y);
                // Vector3 rightPos = new Vector3(xPos, transform.position.y, 0);
                // Vector3 leftPos = new Vector3(-xPos, transform.position.y, 0);

                Vector3 rightPos = spawnLocations[1].position;
                Vector3 leftPos = spawnLocations[0].position;

                var leftTear = GameObject.Instantiate(enemyPrefab, leftPos, Quaternion.identity);
                var rightTear = GameObject.Instantiate(enemyPrefab, rightPos, Quaternion.identity);


                float moveSpeed = Random.Range(tearSpeed.x, tearSpeed.y);
                float horizontalMove = Random.Range(tearSpeedHorizontal.x, tearSpeedHorizontal.y);
                horizontalMove = (Random.Range(0, 10) <= 5)? horizontalMove : -horizontalMove;

                leftTear.GetComponent<TearController>().moveSpeed = moveSpeed;
                rightTear.GetComponent<TearController>().moveSpeed = moveSpeed;
                leftTear.GetComponent<TearController>().horizontalMoveSpeed = horizontalMove;
                rightTear.GetComponent<TearController>().horizontalMoveSpeed = -horizontalMove;
            }
            else {
                int spawnLocationIndex = Random.Range(0, spawnLocations.Length);
                bool isLeft = spawnLocationIndex == 0;
                Vector3 spawnPosition = spawnLocations[spawnLocationIndex].position;
                float tearMoveWidth = Random.Range(tearDirectionConstraints.x, tearDirectionConstraints.y);
                Vector2 tearMoveConstraints = new Vector2(spawnPosition.x - tearMoveWidth, spawnPosition.y + tearMoveWidth);

                var tear = GameObject.Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                tear.GetComponent<TearController>().moveSpeed = Random.Range(tearSpeed.x, tearSpeed.y);
                float horizontalMove = Random.Range(tearSpeedHorizontal.x, tearSpeedHorizontal.y);
                tear.GetComponent<TearController>().horizontalMoveSpeed = (isLeft)? -horizontalMove : horizontalMove;
                tear.GetComponent<TearController>().moveConstraints = tearMoveConstraints;
            }
            
            timer = 0;
        }

        timer += Time.deltaTime;
        float playerPos = Mathf.Lerp(startingPlayerPos, maxPlayerPosForDirectionChange, player.position.y);
        float playerPosPercent = (player.position.y - startingPlayerPos) / (maxPlayerPosForDirectionChange - startingPlayerPos);
        tearSpeedHorizontal.x = Mathf.Lerp(startingHorizontal, maxInwardDirection, playerPosPercent);
    }
}
