using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneManager : MonoBehaviour {

    [SerializeField] Text debugText;

   

    public Text timerText;
    public Slider hourGlassSldr;

    public bool canStart = false;
    public float multiplier;
    // Start is called before the first frame update
    void Start()
    {
       
        canStart = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canStart) {
            this.debugText.text = GameManager.Instance.StateOfPlayer.ToString();

            if(GameManager.Instance.TimerStarted && GameManager.Instance.TimeRemaining > 0) {

                StartCountDownTimer();

            }
        }
    }


    public void StartCountDownTimer() {

        float tempTimeRemaining = GameManager.Instance.TimeRemaining;
        tempTimeRemaining -= (Time.deltaTime * multiplier);
        timerText.text = "Time: " + tempTimeRemaining + " : " + GameManager.Instance.StateOfPlayer;
        hourGlassSldr.value = tempTimeRemaining;

        GameManager.Instance.TimeRemaining = tempTimeRemaining;
        GameManager.Instance.prevTimeRemaining = tempTimeRemaining;

    }

   
}
