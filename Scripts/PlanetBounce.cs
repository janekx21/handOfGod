using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBounce : MonoBehaviour {
    public float force = 1000;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision c) {
        if(c.gameObject.tag == "Player") {
            Rigidbody rig = c.gameObject.GetComponent<Rigidbody>();
            //rig.velocity.Scale(new Vector3(20, 20, 20));
            rig.AddExplosionForce(force, c.contacts[0].point, 20);
        }
        Debug.Log(c.gameObject);
    }
}
