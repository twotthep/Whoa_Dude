using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    public GameObject player; //Please drag Player GameObject to this in  Unity's Inspector.

    private Vector3 offset; //offset between Player and Camera

	// Use this for initialization
	void Start () {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
