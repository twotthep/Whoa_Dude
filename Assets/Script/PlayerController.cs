using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D player;
    public int maxSpeed = 5;
    //private Sprite pSprite;
    public string chgTo;

    public int numOfitemtoKeep = 0;

    GameObject objToDestroy;
    bool canDestroy = false;

    bool walkThroughDoor = false;
    public GameObject triggered;
    public GameObject untriggered;
    public GameObject reveal;

    Animator anim;
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("walk", 0);
        triggered.SetActive(false);
        untriggered.SetActive(true);
        reveal.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)   //Normal Collision 
    { 
        /*if (collision.gameObject.tag == "door")
        {
            Application.LoadLevel(chgTo);
            print("Collide");
        }*/
       
    }
    private void OnTriggerEnter2D(Collider2D collision)     //Trigger Collision
    {
        if (collision.gameObject.tag == "item")
        {
            print("Collide item");
            objToDestroy = collision.gameObject;
            canDestroy = true;
            
        }

        if (collision.gameObject.tag == "door")
        {
            if (numOfitemtoKeep == 0)
            {
                Application.LoadLevel(chgTo);
                print("Collide");
            }
            else
            {
                triggered.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "disable")
        {
            
            untriggered.SetActive(false);
            triggered.SetActive(true);
                Destroy(collision);
        }
        if(collision.gameObject.tag == "enable")
        {
            untriggered.SetActive(true);
            reveal.SetActive(true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="item")
        {
            print("Pass from item");
            canDestroy = false;
        }
    }

    // Update is called once per frame
    private void Update()
    {

        if (Input.GetKey(KeyCode.D))                        //Go Right
        {
            anim.SetInteger("walk", 1);
            // player.velocity += new Vector2(maxSpeed, 0.0f);
            player.transform.localRotation = Quaternion.Euler(0, 0, 0);
           // player.AddForce(Vector2.right * maxSpeed);
           player.velocity = new Vector2(10.0f, 0.0f);
            
        }
        else if (Input.GetKey(KeyCode.A))                   //Go Left
        {
            anim.SetInteger("walk", 1);
            // player.velocity += new Vector2(-maxSpeed, 0.0f);
            player.transform.localRotation = Quaternion.Euler(0, 180, 0);
           // player.AddForce(Vector2.left * maxSpeed);
            player.velocity = new Vector2(-10.0f, 0.0f);
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("walk", 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))                   //Jump
        {
            player.velocity += new Vector2(0.0f, 10.0f);
        }
        if (Input.GetKeyDown(KeyCode.E) && canDestroy)
        {
            if (numOfitemtoKeep > 0)
            {
                numOfitemtoKeep -= 1;
            }
            print("Collected item");
            Destroy(objToDestroy);
        }

    }
    
}
