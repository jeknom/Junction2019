using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState
{
    YOUNG,
    OLD
}

public class GameManager :GenericSingletonClass<GameManager> {
    // Here create all the states that are going to be handled once like young/old 
    PlayerState stateOfPlayer = PlayerState.OLD;

#if UNITY_ANDROID
    ScreenOrientation previousOrientation;
    ScreenOrientation youngOrientation;
    ScreenOrientation oldOrientation;
#endif

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

    private float timeRemaining;
    public float TimeRemaining {
        get {
            return this.timeRemaining;
        }
        set {
            this.timeRemaining = value;
        }
    }

    public float prevTimeRemaining { get; set; }

    [SerializeField]
    private int triesRemaining = 3;

    public float timeLimit = 50f;

    private MainSceneManager mainSceneManager;
    public MainSceneManager varMainSceneManager {
        get {
            return this.mainSceneManager;
        }
        set {
            this.mainSceneManager = value;
        }
    }


    private void Start()
    {
        prevTimeRemaining = 0;
        timeRemaining = 0;

#if UNITY_ANDROID

        var currentOrientation = Screen.orientation;

        this.oldOrientation = currentOrientation;
        this.youngOrientation =
            currentOrientation == ScreenOrientation.LandscapeLeft
                ? ScreenOrientation.LandscapeRight
                : ScreenOrientation.LandscapeLeft;
#endif


    }


    void Update() {

#if UNITY_ANDROID
        var currentOrientation = Screen.orientation;

        if (previousOrientation != currentOrientation)
        {
            this.SetPlayerAgeWithOrientation(currentOrientation);
        }
#endif

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.stateOfPlayer = this.stateOfPlayer == PlayerState.OLD
                ? PlayerState.YOUNG
                : PlayerState.OLD;
            timerStarted = false;
        }
#endif

        Debug.Log(this.stateOfPlayer);

        if(!varMainSceneManager) {

            varMainSceneManager = (MainSceneManager)GameObject.FindObjectOfType<MainSceneManager>();

        }
        else {

            TimerHandler();

        }

    }


    void SetPlayerAgeWithOrientation(ScreenOrientation deviceOrientation)
    {
        if (deviceOrientation == this.youngOrientation)
        {
            this.stateOfPlayer = PlayerState.YOUNG;
        }
        else if (deviceOrientation == this.oldOrientation)
        {
            this.stateOfPlayer = PlayerState.OLD;

        }

        this.previousOrientation = deviceOrientation;

    }


    private void TimerHandler() {

        if(varMainSceneManager.canStart && !timerStarted) {

            if(stateOfPlayer == PlayerState.OLD) {
          
                timeRemaining = timeLimit - prevTimeRemaining;
                varMainSceneManager.multiplier = 0.5f;
                timerStarted = true;

            }
            if(stateOfPlayer == PlayerState.YOUNG) {
                
                timeRemaining = timeLimit - prevTimeRemaining;
                varMainSceneManager.multiplier = 1f;
                timerStarted = true;

            }
        }
    }

    // Generic scene management
    public void GoToScene(string name) {
        SceneManager.LoadScene(name);
    }
}
