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
    public GameObject triggered;
    public GameObject untriggered;
    public GameObject reveal;

    bool collidoor = false;
    public GameObject ghost;
    public GameObject blackBg;

    public AudioSource doorLocked;
    public AudioSource doorUnlocked;

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
    }
    void Play()
    {

    }
    
}
