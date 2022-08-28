using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearController : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 moveDirection = new Vector3(0,-1,0);

    void Update()
    {
        Vector2 verticalScroll = new Vector2(0, -moveSpeed * Time.deltaTime);

        transform.Translate(-transform.up * moveSpeed * Time.deltaTime);
    }
}
