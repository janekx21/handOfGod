using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetReciver : MonoBehaviour {
    public GameObject planetParent;
    private Animator anim;
    public bool hasSnipped = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1") && !hasSnipped) {
            attack();
        }
	}

    void attack() {
        anim.Play("Armature|Snip");
        hasSnipped = true;
    }

    public void Snip() {
        planetParent.GetComponent<Planet>().Snip();
    }
}
