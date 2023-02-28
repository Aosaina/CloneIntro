using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float PlayerSpeed = 1f;

    bool haveKey = false;

    public GameObject chickenText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;

        if (Input.GetKey(KeyCode.W))
        {
            newPos.y += PlayerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            newPos.y -= PlayerSpeed * Time.deltaTime;
            Debug.Log("going down");
        }

        if (Input.GetKey(KeyCode.A))
        {
            newPos.x -= PlayerSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))
        {
            newPos.x += PlayerSpeed * Time.deltaTime;
        }

        transform.position = newPos;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "key")
        {
            haveKey = true;
            //play sound
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "door" && haveKey == true)
        {
            //play sound
            Destroy(other.gameObject);
        }
    }
}