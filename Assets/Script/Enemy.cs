using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
 
    public Transform target; //Please drag Player GameObject to this in  Unity's Inspector.
    private int moveSpeed = 2;
    private Vector3 offset; //offset between Player and Camera
    
	// Use this for initialization
	void Start () {
       
    }
    void LateUpdate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        transform.position += targetDirection * moveSpeed * Time.deltaTime;
    }
}
