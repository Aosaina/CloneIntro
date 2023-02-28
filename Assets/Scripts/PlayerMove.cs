using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    bool haveKey = false;

    public GameObject NpcTextNoKey;

    //public GameObject NpcText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "key")
        {
            haveKey = true;
            Destroy(other.gameObject);
        }

        if (haveKey == true && other.gameObject.name == "door")
        {
            Destroy(other.gameObject);

        }

        if(other.gameObject.name == "npc" && !haveKey)
        {
            Input.GetKeyDown(KeyCode.Space);
            NpcTextNoKey.SetActive(true);
        }

    }
}
