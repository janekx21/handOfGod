using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    public GameObject target;
    public Vector3 offsetNormal;
    public Vector3 offsetWide;
    public Vector3 offsetPre;
    public float mult = 0.1f;
    // Use this for initialization
    //private Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.2F;
    private Vector3 tar;

    public Animator camShake;
    void Start () {
        
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 targetPosition = Vector3.zero;
        Vector3 offset = Vector3.Lerp(offsetNormal, offsetWide, target.GetComponent<Rigidbody>().velocity.magnitude * mult);
        if (target.GetComponent<Planet>()) {
            if (!target.GetComponent<Planet>().hasBeenSnipped) {
                offset = offsetPre;
            }
        }
        targetPosition = target.transform.position - offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);

        //tar = Vector3.SmoothDamp(tar, target.transform.position, ref velocity, smoothTime);
        tar = target.transform.position;
        transform.LookAt(tar);
    }

    public void Shake() {
        camShake.Play("Shake|Action");
    }
}
