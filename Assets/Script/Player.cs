using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health;
    public string name;
    private bool player_state;

    //public Weapon weapon_type;
    public int GetHealth()      //return Player's health
    {
        return health;
    }
    void SetHealth(int hp)      //increase or decrease Player's health
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
