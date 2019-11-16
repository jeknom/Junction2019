using UnityEngine;
using UnityEngine.UI;

public class MainSceneManager : MonoBehaviour {
    [Header("Tries")]
    [SerializeField] int tries = 3;
    [SerializeField] float time = 10;
    [SerializeField] Text triesRemainingText;

    public Text timerText;
    public Slider hourGlassSldr;
    public bool canStart = false;
    public float multiplier;

    void Start()
    {
        //GameManager.Instance.triesRemaining = this.tries;
        //GameManager.Instance.TimeRemaining = this.time;
        canStart = true;
    }

    void Update()
    {
        if (GameManager.Instance.triesRemaining <= 0 ||
            GameManager.Instance.TimeRemaining <= 0)
        {
            GameManager.Instance.reset();
            GameManager.Instance.GoToScene("GameOver");
        }

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
