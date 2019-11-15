using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager :GenericSingletonClass<GameManager> {


    // Here create all the states that are going to be handled once like young/old 

    private string stateOfPlayer;
    public string StateOfPlayer {
        get {
            return this.stateOfPlayer;
        }
        set {
            this.stateOfPlayer = value;
        }
    }

    void Start() {

    }

    void Update() {

    }

    // Generic scene management
    public void GoToScene(string name) {
        SceneManager.LoadScene(name);
    }
}
