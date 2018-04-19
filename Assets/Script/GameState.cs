using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public string level;
    //public string nextLevel;
    public string chgTo;

    public int numOfitemtoKeep = 0;

    GameObject objToDestroy;
    bool canDestroy = false;

    bool walkThroughDoor = false;
    //Global GameObject
    public GameObject triggered;
    public GameObject untriggered;
    public GameObject reveal;

    bool collidoor = false;
    public GameObject ghost;
    public GameObject blackBg;

    public AudioSource doorLocked;
    public AudioSource doorUnlocked;

    //Level 3 GameObject
    public GameObject lv3_1obj; //White Sign
    public GameObject lv3_2obj; //Grey Sign
    bool getItemLv3_1 = false;

    bool canGetIn = false;

    Animator anim;

    void Main()
    {
        if (level == "1")
        {
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "door")
        {
            if(canGetIn == true)
            {
                    
            }
            
            //Level 3 Editor
            if(level == "3")
            {
                lv3_1obj.SetActive(true);
            }

        }
        if(collider.gameObject.tag == "item")
        {
            print("Collide item");
            if(level == "3")
            {
                getItemLv3_1 = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "item")
        {
            print("Out from item");
            if (level == "3")
            {
                getItemLv3_1 = false;
            }
        }
    }
    void Loadlevel(string name)
    {
        Application.LoadLevel(name);
    }
    void Pause()
    {
        ////
    }
	// Use this for initialization
	void Start () {
        SetStart(level);
       // player.GetComponent<Collider2D>();
     /*   player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("walk", 0);
        triggered.SetActive(false);
        untriggered.SetActive(true);
        reveal.SetActive(false);
        ghost.SetActive(false);
        blackBg.SetActive(false);*/
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E) && canGetIn)
        {
            
            if (level == "1")
            {
                Loadlevel("2");
            }
            if (level == "2")
            {
                Loadlevel("3");
            }
            if (level == "3")
            {
                Loadlevel("4");
            }
        }
        if(Input.GetKeyDown(KeyCode.E) && getItemLv3_1)
        {
            Destroy(lv3_1obj);
            canGetIn = true;
        }
   
}

void SetStart(string level)
    {
        if(level == "1")
        {
            canGetIn = true;
        }
        if(level == "2")
        {
            canGetIn = true;
        }
        if(level == "3")
        {
            canGetIn = false;
            lv3_1obj.SetActive(false);
        }
    }
    void Play()
    {

    }
    
}
