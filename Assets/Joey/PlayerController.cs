using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 moveSpeed;
    public Transform left;
    public Transform right;
    public Vector2 xConstraints;
    public GameObject sadFace;
    public GameObject happyFace;
    public GameObject explosion;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    void Update()
    {
        if(left == null) return;

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


    public void OnDeath(bool won = false)
    {
        Debug.Log("EXPLOSION");
        GameObject.Instantiate(explosion, left.transform.position, Quaternion.identity);
        GameObject.Instantiate(explosion, right.transform.position, Quaternion.identity);

        Destroy(left.gameObject);
        Destroy(right.gameObject);
        moveSpeed = Vector2.zero;

        if(!won) {
            GetComponent<AudioSource>().Play();
        }

    }


    public void OnWin()
    {
        Destroy(sadFace);
        happyFace.SetActive(true);
        OnDeath();


    }
}
