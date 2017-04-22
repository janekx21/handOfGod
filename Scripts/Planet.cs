using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {
    public float force = 50;
    public bool hasBeenSnipped = false;
    public float mult;
    private Vector3 fo;
    private bool dead = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        LineRenderer lr = GetComponent<LineRenderer>();
        if (!hasBeenSnipped) {
            GetComponent<Rigidbody>().Sleep();
            
            Vector3 mPos = Input.mousePosition;
            mPos.x -= Screen.width / 2;
            mPos.y -= Screen.height / 2;
            mPos *= mult;
            if(mPos.magnitude > 4) {
                mPos = mPos.normalized* 4;
            }
            lr.SetPosition(1, new Vector3(0,mPos.y,-mPos.x));
            fo = new Vector3(0, mPos.y, -mPos.x);
        }
        else {
            lr.SetPosition(1, Vector3.zero);
        }
        if (dead) {
            GetComponent<Rigidbody>().Sleep();
        }
	}

    public void Snip() {
        hasBeenSnipped = true;
        GetComponent<Rigidbody>().AddForce(fo * force);
    }

    void OnCollisionEnter(Collision c) {
        GameObject.Find("cam").GetComponent<CamFollow>().Shake();
    }

    public void die() {
        dead = true;
        foreach(Renderer ren in GetComponentsInChildren<Renderer>()) {
            ren.material.color = Color.black;
        }
    }
}
