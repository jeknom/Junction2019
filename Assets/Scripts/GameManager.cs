using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : GenericSingletonClass<GameManager> {

public enum PlayerState
{
    YOUNG,
    OLD
}

public class GameManager :GenericSingletonClass<GameManager> {
    // Here create all the states that are going to be handled once like young/old 
    PlayerState stateOfPlayer;

    public PlayerState StateOfPlayer {
        get {
            return this.stateOfPlayer;
        }
        set {
            this.stateOfPlayer = value;
        }
    }

    private bool flip;
    public bool Flip {
        get {
            return this.flip;
        }
        set {
            this.flip = value;
        }
    }

    private MainSceneManager mainSceneManager;
    public MainSceneManager varMainSceneManager {
        get {
            return this.mainSceneManager;
        }
        set {
            this.mainSceneManager = value;
        }
    }

    private bool timerStarted;
    public bool TimerStarted {
        get {
            return this.timerStarted;
        }
        set {
            this.timerStarted = value;
        }
    }

    void Start() {

    }

    void Update() {

        if(!varMainSceneManager) {

            varMainSceneManager = (MainSceneManager)GameObject.FindObjectOfType<MainSceneManager>();

        }
        else {
            if(varMainSceneManager.canStart && !timerStarted) {
                if(flip) {

                    stateOfPlayer = "young";
                    TimerStarted = true;
                }
                else if(!flip) {

                    stateOfPlayer = "old";
                    TimerStarted = true;
                }
            }
        }


    }

    // Generic scene management
    public void GoToScene(string name) {
        SceneManager.LoadScene(name);
    }
}
