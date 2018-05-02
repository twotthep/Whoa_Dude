using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D player;
    public int maxSpeed = 5;

    Animator anim;
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        anim.SetInteger("walk", 0);
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
           player.velocity = new Vector2(maxSpeed, 0.0f);
            
        }
        else if (Input.GetKey(KeyCode.A))                   //Go Left
        {
            anim.SetInteger("walk", 1);
            // player.velocity += new Vector2(-maxSpeed, 0.0f);
            player.transform.localRotation = Quaternion.Euler(0, 180, 0);
           // player.AddForce(Vector2.left * maxSpeed);
            player.velocity = new Vector2(-maxSpeed, 0.0f);
        }
        else if(Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("walk", 0);
            player.velocity = new Vector2(0.0f,0.0f);
        }
        /*else if (Input.GetKeyDown(KeyCode.W))                   //Jump
        {
            player.velocity += new Vector2(0.0f, 10.0f);
        }*/
       

    }
    
}
     