using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D player;
	// Use this for initialization
	void Start () {
        player = GetComponent<Rigidbody2D>();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("item") && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(collision.gameObject);
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
    }
}
