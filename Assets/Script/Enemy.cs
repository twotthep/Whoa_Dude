using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public string name;

    public Transform Player;
    public int moveSpeed = 5;
    public int maxDist = 10;
    public int minDist = 5;

    int GetHealth()         //return Enemy's Health
    {
        return health;
    }
    void SetHealth(int hp)  //increase or decrease Enemy's health
    {
        health += hp;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= minDist)
        {

            transform.position += transform.forward * moveSpeed * Time.deltaTime;



            if (Vector3.Distance(transform.position, Player.position) <= maxDist)
            {
                //Here Call any function U want Like Shoot at here or something
            }
        }
        }
}
