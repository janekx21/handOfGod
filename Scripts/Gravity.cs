using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour {
    private GameObject player;
    public float maxDis;
    public float gravity;
    int size;
    float theta_scale  = .1f; //Set lower to add more points
    LineRenderer lineRenderer;
    AudioSource audioS;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("planet");
        makeGravityLine(maxDis);
        if(Input.GetButtonDown("Fire2")){
            lineRenderer.enabled = true;
        }
        audioS = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update() {
        float dis = Vector3.Distance(player.transform.position, transform.position);
        if(maxDis > dis) {
            //float mult = Mathf.Lerp(0, gravity, dis/maxDis);//////dis <-> maXDis
            float orMult = (((dis / maxDis) * (-1)) + 1); // orginal multiplayer
            float mult = orMult * gravity*10;               //mult by gavity
            //Debug.Log("dis: " + dis + "maxDis: " + maxDis + "a: "+((dis/maxDis)*(-1))+1);
            if (audioS) {
                audioS.volume = orMult;
            }
            Vector3 dir = player.transform.position - transform.position;
            dir.Normalize();
            player.GetComponent<Rigidbody>().AddForce(dir * mult);
        }
        if (Input.GetButton("Fire2")) {
            if (!lineRenderer.enabled) {
                lineRenderer.enabled = true;
            }
            upddateLinePos(maxDis);
        }
        else {
            if (lineRenderer.enabled) {
                lineRenderer.enabled = false;
            }
        }
        
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, maxDis);
    }

    void makeGravityLine(float r) {
                  
        size = (int)Mathf.Floor((2.0f * Mathf.PI) / theta_scale); //Total number of points in circle.

        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        Color c1 = Color.HSVToRGB(-gravity / 50, 1, 1);
        Color c2 = Color.HSVToRGB(-gravity/50, 1, 1);
        lineRenderer.SetColors(c1, c2);
        lineRenderer.startWidth= -gravity / 10;
        //lineRenderer.SetWidth(0.2F, 0.2F);
        lineRenderer.SetVertexCount(size+1);
        //lineRenderer.useWorldSpace = false;

        int i = 0;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f) {
            float x = r * Mathf.Cos(theta);
            float y = r * Mathf.Sin(theta);

            x += transform.position.z;
            y += transform.position.y;

            Vector3 pos = new Vector3(transform.position.x, y, x);
            lineRenderer.SetPosition(i, pos);
            i += 1;
        }
    }
    void upddateLinePos(float r) {
        int i = 0;
        for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f) {
            float x = r * Mathf.Cos(theta);
            float y = r * Mathf.Sin(theta);

            x += transform.position.z;
            y += transform.position.y;

            Vector3 pos = new Vector3(transform.position.x, y, x);
            lineRenderer.SetPosition(i, pos);
            i += 1;
        }
    }
}
