using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {
    public byte state = 0x00;
    private float timer = 2;
    public GameObject anyKeyText;
    public GameObject panel;
    public Vector3 targetPos;
    [Range(0,1)]
    public float lerpSmoth = .1f;

    // Use this for initialization
    void Start () {
        anyKeyText.SetActive(false);
        targetPos = panel.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Input.anyKeyDown && state == 0x01) {
            state = 0x02;
            //targetPos += new Vector3(5000, 0, 0);
            LevelSelect();
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Exit();
        }
        timer -= Time.deltaTime;
        if(timer < 0) {
            if(state == 0x00) {
                state = 0x01;
                anyKeyText.SetActive(true);
            }
        }

        panel.transform.position = Vector3.Lerp(panel.transform.position, targetPos, lerpSmoth);
    }
    public void loadLevel(int lvl) {
        SceneManager.LoadScene(lvl);
    }
    void Exit() {
        Application.Quit();
    }
    public void LevelSelect() {
        targetPos = new Vector3(5000, 0, 0);
    }
    public void howToPlay() {
        targetPos = new Vector3(5000, -5000, 0);
    }
}


