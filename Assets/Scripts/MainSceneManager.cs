using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour {
    [SerializeField] Text triesRemainingText;
    public Text timerText;
    public Slider hourGlassSldr;
    public bool canStart = false;
    public float multiplier;

    void Start()
    {
        canStart = true;
    }

    void Update()
    {
        this.triesRemainingText.text =
            "Rotates remaining: " + GameManager.Instance.triesRemaining.ToString();

        if (canStart) {
            if(GameManager.Instance.TimerStarted && GameManager.Instance.TimeRemaining > 0) {
                StartCountDownTimer();
            }
        }
    }


    public void StartCountDownTimer() {
        float tempTimeRemaining = GameManager.Instance.TimeRemaining;
        tempTimeRemaining -= (Time.deltaTime * multiplier);
        timerText.text =
            "Time: " + Mathf.RoundToInt(tempTimeRemaining) + " : " + GameManager.Instance.StateOfPlayer;
        hourGlassSldr.value = tempTimeRemaining;

        GameManager.Instance.TimeRemaining = tempTimeRemaining;
        GameManager.Instance.prevTimeRemaining = tempTimeRemaining;
    }
}
