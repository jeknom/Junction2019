using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour {

    [SerializeField] Text debugText;

    public float timeLimit = 100f;
    public float timeRemaining;

    public Text timerText;
    public Slider hourGlassSldr;

    public bool canStart = false;
    public float multiplier;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = 0;
        canStart = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        this.debugText.text = GameManager.Instance.StateOfPlayer.ToString();
        if(GameManager.Instance.TimerStarted) {

            StartCountDownTimer();

        }
    }


    public void StartCountDownTimer() {

        if(timeRemaining < timeLimit) {

            timeRemaining += (Time.deltaTime * multiplier);
            timerText.text = "Time: " + timeRemaining + " : " + GameManager.Instance.StateOfPlayer;

        }
        else {

            //GameManager.Instance.Flip = !GameManager.Instance.Flip;
            GameManager.Instance.TimerStarted = false;

            timeRemaining = timeLimit;
        }

    }

   
}
