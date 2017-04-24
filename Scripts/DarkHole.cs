using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkHole : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Gravity>()) {
            
        }
	}
    void OnTriggerEnter(Collider c) {
        if(c.gameObject.tag == "Player") { 
            GameManager.loose();
            if (GameObject.Find("planet")) {
                GameObject.Find("planet").SetActive(false);
            }
        }
    }
}
