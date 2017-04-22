using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour {
    public GameObject playPanel;
    public GameObject deadPanel;
    public GameObject wonPlanel;
    // Use this for initialization
    void Start () {
        setPanel(1);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Reset")) {
            Reset();
        }
	}

    void Reset() {
        GameManager.Reset();
    }

    public void setPanel(byte play) {
        switch (play) {
            case 1:
            playPanel.SetActive(true);
            deadPanel.SetActive(false);
            wonPlanel.SetActive(false);
            break;
            case 0:
            playPanel.SetActive(false);
            deadPanel.SetActive(true);
            wonPlanel.SetActive(false);
            break;
            default:
            Debug.LogWarning("Switch Error");
            break;
            case 2:
            playPanel.SetActive(false);
            deadPanel.SetActive(false);
            wonPlanel.SetActive(true);
            break;
        }
    }
    void Menu() {
        Debug.Log("Menu!");
        GameManager.Menu();
    }

    void Next() {
        Debug.Log("Next!");
        GameManager.Next();
    }
}
