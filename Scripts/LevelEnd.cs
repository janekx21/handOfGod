﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider c) {
        if(c.gameObject.tag == "Player") {
            GameManager.nextLevel();
            if (GetComponent<AudioSource>()) {
                GetComponent<AudioSource>().Play();
            }
            if (GameObject.Find("planet")) {
                GameObject.Find("planet").SetActive(false);
            }
        }
    }
}
