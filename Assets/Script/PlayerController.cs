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
    bool canGetin = false;

    bool walkThroughDoor = false;
    public GameObject triggered;
    public GameObject untriggered;
    public GameObject reveal;

    bool collidoor = false;
    public GameObject ghost;
    public GameObject ghostCol;
    public GameObject Bk_bg;

    public AudioSource doorLocked;
    public AudioSource doorUnlocked;

    Animator anim;
    float currCountdownValue;
    //bool countEnd = false;
    public IEnumerator StartCountdown(float countdownValue = 1)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue >= 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            if(currCountdownValue == 0)
            {
                Destroy(Bk_bg);
            }
            
        }
        
    }
    // Use this for initialization
    void Start () {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("walk", 0);
        triggered.SetActive(false);
        untriggered.SetActive(true);
        reveal.SetActive(true);
        ghost.SetActive(false);
        Bk_bg.SetActive(false);
        ghostCol.SetActive(false);
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
            
            print("Collide with Door");
            if (numOfitemtoKeep == 0)
            {
<<<<<<< HEAD
                if(Input.GetKeyDown(KeyCode.E))
                {
                    Application.LoadLevel(chgTo);
                    print("Collide");
                }
                
=======
                canGetin = true;
                print("Door opened");
>>>>>>> f47ca772d002672826bf3a80edd92867b89a944e
            }
            else
            {
                doorLocked.Play();
                triggered.SetActive(true);
            }
        }
        if (collision.gameObject.tag == "disable")
        {

            //  untriggered.SetActive(false);
            doorLocked.Play();
            triggered.SetActive(true);
             Destroy(collision);
            collidoor = true;
        }
        if(collision.gameObject.tag == "enable")
        {
            if(canGetin == false)
            {
                ghost.SetActive(false);
            }
            untriggered.SetActive(true);
            reveal.SetActive(true);
            //collidoor = true;   
            if (collidoor == true && canGetin == false)
            {
                ghost.SetActive(true);
                ghostCol.SetActive(true);
            }
            else
            {
                ghost.SetActive(false);
            }
        }
        if(collision.gameObject.tag == "away")
        {
            print("Blackout");
            ghost.SetActive(false);
            Bk_bg.SetActive(true);
            StartCoroutine(StartCountdown());
            
            if(currCountdownValue == 0)
            {
                print("Count");
                Bk_bg.SetActive(false);
            }
           
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
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
<<<<<<< HEAD
        /*if(Input.GetKeyDown(KeyCode.E) && )
        {

        }*/
=======
        if (Input.GetKeyDown(KeyCode.E) && canGetin)
        {
            Application.LoadLevel(chgTo);
        }
>>>>>>> f47ca772d002672826bf3a80edd92867b89a944e

    }
    
}
