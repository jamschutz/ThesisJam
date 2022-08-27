using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TearController : MonoBehaviour
{
    public float moveSpeed;

    void Update()
    {
        Vector2 verticalScroll = new Vector2(0, -moveSpeed * Time.deltaTime);
        transform.Translate(verticalScroll);
    }
}
