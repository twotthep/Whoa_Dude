﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {
    public string level;
    //public string nextLevel;

    public int numOfitemtoKeep = 0;

    GameObject objToDestroy;
    bool canDestroy = false;

    bool walkThroughDoor = false;
    //Global GameObject
    public GameObject triggered;
    public GameObject untriggered;
    public GameObject reveal;

    public bool noItemLeft = false;

    bool collidoor = false;

    public AudioSource doorLocked;
    public AudioSource doorUnlocked;

    //Level 3 GameObject
    public GameObject lv3_1obj; //White Sign
    public GameObject lv3_2obj; //Grey Sign
    bool getItemLv3_1 = false;

    //Level 4 GameObject
    public GameObject ghost;
    public GameObject ghostShow;
    public GameObject blackBg;
    bool collideGhost = false;
    bool gotoLastDoorLv4 = false;


    //Level 6 GameObject
    public GameObject enemyLv6;
    bool gotoLastDoorLv6 = false;
    public GameObject playerLv6;

    //Level 8 GameObject
    public GameObject idCardLv8;
    bool getidCardLv8 = false;

    //Level 9 GameObject
    public GameObject enemyLv9;

    //Level 15 GameObject
    public SpriteRenderer bkLightlv15;
    public GameObject ghostLv15;
    public GameObject ghostLv15_2;

        //CountDown thing
    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 2)
    {
        Destroy(ghost);
        Destroy(ghostShow);
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            blackBg.SetActive(true);
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if (currCountdownValue == 0)
        {
            blackBg.SetActive(false);
            
            
        }
    }
    public IEnumerator StartCountdownLv6(float countdownValue = 2)
    {
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if (currCountdownValue == 0)
        {
            Loadlevel("7");
        }
    }

    public IEnumerator StartCountdownLv9(float countdownValue = 2)
    {
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if (currCountdownValue == 0)
        {
            Destroy(enemyLv9);
        }
    }

    
    IEnumerator DoBlinks(float duration, float blinkTime)
    {
        while (duration > 0f)
        {
            duration -= Time.deltaTime;

            //toggle renderer
            bkLightlv15.enabled = !bkLightlv15.enabled;

            //wait for a bit
            yield return new WaitForSeconds(blinkTime);
           
        }
       /* if(duration == 0f)
        {
            Destroy(bkLightlv15);
        }*/
        //make sure renderer is enabled when we exit
       
       bkLightlv15.enabled = true;
        

    }

    public IEnumerator StartCountdownLv7(float countdownValue = 2)
    {
        while (currCountdownValue > 0)
        {
            Time.timeScale = 0;
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }
        if (currCountdownValue == 0)
        {
            Time.timeScale = 1;
        }
    }
    //Global bool for door unlocked
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
            
            //Level Editor
            if(level == "1" || level == "2")
            {
                canGetIn = true;
            }
            if(level == "3")
            {
                lv3_1obj.SetActive(true);
            }
            if(level == "3" && noItemLeft)
            {
                canGetIn = true;
            }
            if(level == "4")
            {
                gotoLastDoorLv4 = true;
            }
            if (level == "4" && noItemLeft)
            {
                canGetIn = true;
            }
            if (level == "5")
            {
                canGetIn = true;
            }
            if(level == "6")
            {
                gotoLastDoorLv6 = true;
            }
            if(level == "7")
            {
                canGetIn = true;
            }
            if(level == "8")
            {
                idCardLv8.SetActive(true);
            }
            if (level == "9")
            {
                canGetIn = true;
            }
            if(level == "10")
            {
                canGetIn = true;
            }
            if(level == "11")
            {
                canGetIn = true;
            }
            if(level == "12")
            {
                canGetIn = true;
            }
            if(level == "13")
            {
                canGetIn = true;
            }
            if (level == "14")
            {
                canGetIn = true;
            }
            if (level == "15")
            {
                canGetIn = true;
            }

        }
        if(collider.gameObject.tag == "item")
        {
            print("Collide item");
            if(level == "3")
            {
                getItemLv3_1 = true;
                noItemLeft = true;
            }
            if(level == "8")
            {
                getidCardLv8 = true;
                noItemLeft = true;
            }
            if(level == "9")
            {
                StartCoroutine(StartCountdownLv9());
            }
            if(level == "15")
            {
                StartCoroutine(DoBlinks(5.0f,0.125f));
              
            }
            
        }
        if(collider.gameObject.tag == "enable")
        {
            if(level == "4" && gotoLastDoorLv4)
            {
                ghost.SetActive(true);
                ghostShow.SetActive(true);
            }
            if(level == "6" && gotoLastDoorLv6)
            {
                enemyLv6.SetActive(true);
                
            }
        }
        if(collider.gameObject.tag == "away")
        {
            print("Collide Away");
            if(level == "4")
            {
                StartCoroutine("StartCountdown", 2);
                collideGhost = true;
                noItemLeft = true;
            }
            if(level == "15")
            {
                Destroy(bkLightlv15);
            }
        }
        if(collider.gameObject.tag == "Enemy")
        {
            if(level == "6")
            {
                playerLv6.transform.Rotate(new Vector3(0, 0, 129));
                playerLv6.transform.Translate(new Vector3(0, 5, 0));
                StartCoroutine(StartCountdownLv6());
            }
            if(level == "15")
            {
                Destroy(collider);
            }
            
        }
        if(collider.gameObject.tag == "disappear")
        {
            if(level == "15")
            {
                ghostLv15.SetActive(true);
                ghostLv15_2.SetActive(false);
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
            if (level == "4")
            {
                Loadlevel("5");
            }
            if(level == "5")
            {
                Loadlevel("6");
            }
            if(level == "7")
            {
                Loadlevel("8");
            }
            if (level == "8")
            {
                Loadlevel("9");
            }
            if (level == "9")
            {
                Loadlevel("10");
            }
            if(level == "10")
            {
                Loadlevel("11");
            }
            if(level == "11")
            {
                Loadlevel("12");
            }
            if(level == "12")
            {
                Loadlevel("13");
            }
            if(level == "13")
            {
                Loadlevel("14");
            }
            if (level == "14")
            {
                Loadlevel("15");
            }
            if (level == "15")
            {
                Loadlevel("gameover");
            }
        }
        if(Input.GetKeyDown(KeyCode.E) && getItemLv3_1)
        {
            Destroy(lv3_1obj);
            canGetIn = true;
        }
        if (Input.GetKeyDown(KeyCode.E) && getidCardLv8)
        {
            Destroy(idCardLv8);
            canGetIn = true;
        }
    }

void SetStart(string level)
    {
        if(level == "1")
        {
           canGetIn = false;
        }
        if(level == "2")
        {
            canGetIn = false;
        }
        if(level == "3")
        {
            canGetIn = false;
            lv3_1obj.SetActive(false);
        }
        if(level == "4")
        {
            canGetIn = false;
            ghost.SetActive(false);
            ghostShow.SetActive(false);
            blackBg.SetActive(false);
        }
        if(level == "5")
        {
            
            canGetIn = false;
        }
        if (level == "6")
        {

            enemyLv6.SetActive(false);
        }
        if(level == "7")
        {
           // Time.timeScale = 0;
            canGetIn = false;
        }
        if(level == "8")
        {
            canGetIn = false;
            idCardLv8.SetActive(false);
        }
        if(level == "9")
        {
            canGetIn = false;
        }
        if(level == "10")
        {
            canGetIn = false;
        }
        if(level == "11")
        {
            canGetIn = false;
        }
        if(level == "12")
        {
            canGetIn = false;
        }
        if(level == "13")
        {
            canGetIn = false;
        }
        if (level == "14")
        {
            canGetIn = false;
        }
        if (level == "15")
        {
            canGetIn = false;
            bkLightlv15.enabled = !bkLightlv15.enabled;
            ghostLv15.SetActive(false);
        }
    }
    void Play()
    {

    }
    
}
