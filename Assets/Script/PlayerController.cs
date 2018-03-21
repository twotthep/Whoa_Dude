using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D player;
    public string chgTo;

    GameObject objToDestroy;
    bool canDestroy = false;
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)   //Normal Collision 
    { 
        if (collision.gameObject.tag == "door")
        {
            Application.LoadLevel(chgTo);
            print("Collide");
        }
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
            Application.LoadLevel(chgTo);
            print("Collide");
        }
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.D))                        //Go Right
        {
            // player.velocity += new Vector2(maxSpeed, 0.0f);
            player.velocity += new Vector2(5.0f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.A))                   //Go Left
        {
            // player.velocity += new Vector2(-maxSpeed, 0.0f);
            player.velocity += new Vector2(-5.0f, 0.0f);
        }
        else if (Input.GetKeyDown(KeyCode.W))                   //Jump
        {
            player.velocity += new Vector2(0.0f, 10.0f);
        }
        if (Input.GetKeyDown(KeyCode.E) && canDestroy)
        {
            Destroy(objToDestroy);
        }
    }
}
