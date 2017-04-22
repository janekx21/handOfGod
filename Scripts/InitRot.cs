using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitRot : MonoBehaviour {
    public Vector3 chance;
	// Use this for initialization
	void Start () {
        Vector3 v = new Vector3(Random.Range(0, chance.y), Random.Range(0, chance.y), Random.Range(0, chance.z));
        GetComponent<Rigidbody>().AddTorque(v,ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
