using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearController : MonoBehaviour
{
    public float moveSpeed;
    public float horizontalMoveSpeed = 4;
    public Vector2 moveConstraints = new Vector2(-15, 15);
    public Vector3 moveDirection = new Vector3(0,-1,0);


    void Start()
    {
    }

    void Update()
    {
        Vector3 movement = new Vector3(horizontalMoveSpeed, -moveSpeed, 0);
        transform.Translate(movement * Time.deltaTime);

        // if(transform.position.x < moveConstraints.x || transform.position.x > moveConstraints.y)
        //     horizontalMoveSpeed *= -1;
    }
}
