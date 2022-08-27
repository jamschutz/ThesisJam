using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveSpeed;
    public Transform left;
    public Transform right;
    public Vector2 xConstraints;


    void Update()
    {
        Vector2 verticalScroll = new Vector2(0, moveSpeed.y * Time.deltaTime);
        transform.Translate(verticalScroll);

        Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), 0) * Time.deltaTime;
        right.Translate(mouseInput * moveSpeed.x);

        // make sure within constraints
        if(right.transform.position.x < xConstraints.x) {
            right.transform.position = new Vector2(xConstraints.x, right.transform.position.y);
        }
        else if(right.transform.position.x > xConstraints.y) {
            right.transform.position = new Vector2(xConstraints.y, right.transform.position.y);
        }

        // mirror left
        left.transform.position = new Vector3(-right.transform.position.x, left.transform.position.y, 0);
    }


    void Move()
    {

    }
}
