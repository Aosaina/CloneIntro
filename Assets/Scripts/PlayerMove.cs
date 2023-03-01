using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;

    bool haveKey = false;
    bool endGame = false;

    public GameObject NpcTextNoKey;
    public GameObject NpcTextYesKey;
    public GameObject NpcTextExit;

    public AudioSource mySource;
    public AudioClip keySound;
    public AudioClip doorSound;
    public AudioClip npcSound;


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

        //Debug.Log(Input.GetKeyDown(KeyCode.Space));

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "key")
        {
            haveKey = true;
            mySource.PlayOneShot(keySound);
            Destroy(other.gameObject);
        }

        if (haveKey == true && other.gameObject.name == "door")
        {
            mySource.PlayOneShot(doorSound);
            Destroy(other.gameObject);
          

        }
      
        
        if(other.gameObject.name == "npc" && Input.GetKeyDown(KeyCode.Space))
        {
            mySource.PlayOneShot(npcSound);
            if (haveKey)
            {          
                NpcTextYesKey.SetActive(true);
            } else
            {
                NpcTextNoKey.SetActive(true);
            }
        }

        if (other.gameObject.name == "npc2" && Input.GetKeyDown(KeyCode.Space))
        { 
            mySource.PlayOneShot(npcSound);
            NpcTextExit.SetActive(true);
            endGame = true;
        }

        if (other.gameObject.name == "bush" && endGame)
        {
            //scene change
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "npc")
        {
            NpcTextYesKey.SetActive(false);
            NpcTextNoKey.SetActive(false);
        }

        if (other.gameObject.name == "npc2")
        {
            NpcTextExit.SetActive(false);
        }
    }
}
