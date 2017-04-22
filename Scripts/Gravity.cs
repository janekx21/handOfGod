using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    private GameObject player;
    public float maxDis;
    public float gravity;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("planet");
	}
	
	// Update is called once per frame
	void Update() {
        float dis = Vector3.Distance(player.transform.position, transform.position);
        if(maxDis > dis) {
            float mult = Mathf.Lerp(0, gravity, maxDis / dis);
            Vector3 dir = player.transform.position - transform.position;
            dir.Normalize();
            player.GetComponent<Rigidbody>().AddForce(dir * mult);
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, maxDis);
    }
}
