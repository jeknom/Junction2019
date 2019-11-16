using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    YOUNG,
    OLD
}

public class GameManager : GenericSingletonClass<GameManager> {
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


    private bool timerStarted;
    public bool TimerStarted {
        get {
            return this.timerStarted;
        }
        set {
            this.timerStarted = value;
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

    private DeviceOrientation oldOrientation { get; set; }
    private DeviceOrientation youngOrientation { get; set; }

    private MainSceneManager mainSceneManager;
    public MainSceneManager varMainSceneManager {
        get {
            return this.mainSceneManager;
        }
        set {
            this.mainSceneManager = value;
        }
    }


    void Start() {

        oldOrientation = Input.deviceOrientation;
        if(oldOrientation == DeviceOrientation.LandscapeLeft) {

            youngOrientation = DeviceOrientation.LandscapeRight;

        }
        else if(oldOrientation == DeviceOrientation.LandscapeRight) {

            youngOrientation = DeviceOrientation.LandscapeLeft;

        }

    }

    void Update() {

        DeviceOrientation tempOrientation  = Input.deviceOrientation;

        if(tempOrientation.Equals(youngOrientation) && this.stateOfPlayer != PlayerState.YOUNG) {

            this.stateOfPlayer = PlayerState.YOUNG;

        }
        else if(tempOrientation.Equals(oldOrientation) && this.stateOfPlayer != PlayerState.OLD) {

            this.stateOfPlayer = PlayerState.OLD;

        }

        Debug.Log(this.stateOfPlayer);

        if(!varMainSceneManager) {

            varMainSceneManager = (MainSceneManager)GameObject.FindObjectOfType<MainSceneManager>();

        }
        else {

            if(varMainSceneManager.canStart && !timerStarted) {

                if(flip) {

                    stateOfPlayer = PlayerState.YOUNG;
                    varMainSceneManager.multiplier = 1f;
                    TimerStarted = true;
                }
                else if(!flip) {

                    stateOfPlayer = PlayerState.OLD;
                    varMainSceneManager.multiplier = 0.5f;
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
