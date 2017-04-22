using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Folow : MonoBehaviour {
    public Vector3 offset;
    public Transform target;
    public float mult;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position - offset;
        float dis = Vector3.Distance(GameObject.Find("cam").transform.position, transform.position) * mult;
        transform.localScale = Vector3.one * dis;
        if(dis < 1) {
            transform.localScale = Vector3.zero;
        }
    }
}
