using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour {

    public float timeLimit = 100f;
    public float timeRemaining;

    public Text timerText;
    public bool canStart = false;
    // Start is called before the first frame update
    void Start()
    {
        timeRemaining = timeLimit;
        canStart = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.TimerStarted) {

            StartCountDownTimer();

        }
    }


    public void StartCountDownTimer() {

        if(timeRemaining > 0) {

            timeRemaining -= (Time.deltaTime);
            timerText.text = "Time: " + timeRemaining;

        }
        else {

            GameManager.Instance.Flip = !GameManager.Instance.Flip;
            GameManager.Instance.TimerStarted = false;

            timeRemaining = timeLimit;
        }

    }

   
}
