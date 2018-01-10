using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int health;
    public string name;

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
		
	}
}
