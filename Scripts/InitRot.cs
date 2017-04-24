using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitRot : MonoBehaviour {
    public Vector3 chance;
	// Use this for initialization
	void Start () {
        Vector3 v = new Vector3(Random.Range(-chance.x, chance.x), Random.Range(-chance.y, chance.y), Random.Range(-chance.z, chance.z));
        GetComponent<Rigidbody>().AddTorque(v,ForceMode.VelocityChange);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
