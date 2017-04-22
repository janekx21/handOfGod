using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
    public static void loose() {
        GameObject.Find("planet").GetComponent<Planet>().die();
        GameObject.Find("Canvas").GetComponent<UIScript>().setPanel(0);
    }

    public static void nextLevel() {
        Debug.Log("Finish!");
        GameObject.Find("planet").GetComponent<Planet>().die();
        GameObject.Find("Canvas").GetComponent<UIScript>().setPanel(2);
    }

    public static void Reset() {
        Debug.Log("Reset!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public static void Next() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }

    public static void Menu() {
        SceneManager.LoadScene(0);
    }
}
