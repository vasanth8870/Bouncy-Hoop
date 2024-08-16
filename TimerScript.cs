using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    public Image timerBar;
    public float maxTime = 10f; // Total time for the timer

    public float timeLeft;
    public bool isTimerActive = false;
    private Coroutine timerCoroutine;

    public float level;
    public TextMeshProUGUI levelText;
    // public int currentlevelcount;

    public PlayController playcontroller;
    public SpawnContaller spawnContoller;

    public int currentLevel = 0;
    public int maxLevel = 50;
    /* public int scoreToNextLevel = 10;
     private int currentScore = 0;*/

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = maxTime;
        Debug.Log(timeLeft + "timeleft = maxtime");
        timerBar.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        LevelTimerBar();
    }

    public void LevelTimerBar()
    {
        if (isTimerActive)
        {

            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                Debug.Log(timeLeft + "timer left------");
                TimerBar();

            }
            else
            {
                timeLeft = 0;
                Debug.Log(timeLeft + "timefinished...");
                timerBar.gameObject.SetActive(false);
                Debug.Log(timerBar + "timerBar deactive-----");
                isTimerActive = false;
                currentLevel = 0;
                levelText.gameObject.SetActive(false);

            }
        }
    }

    public void ResetTimer()
    {
        Debug.Log(playcontroller.scored + "ball scored true))))))");
        isTimerActive = true;
        timeLeft = maxTime;
        timerBar.gameObject.SetActive(true);
        Debug.Log(timerBar + "timerBar active+++++");
        levelText.gameObject.SetActive(true);
    }

    public void TimerBar()
    {
        timerBar.fillAmount = timeLeft / maxTime;
        Debug.Log(timerBar.fillAmount + "timerBar.fillAmount----");
    }

    public void Levels()
    {
        IncreaseLevel();
        /*if (playcontroller.scored == true)
        {
            level += 1;
            levelText.text = level.ToString();
            
        }*/

    }

    public void IncreaseLevel()
    {
        if (playcontroller.scored)
        {
            if (currentLevel < maxLevel)
            {
                currentLevel += 1;
                levelText.text = currentLevel.ToString();
                Debug.Log(levelText.text + "level text....");
                //currentScore = 0; // Reset score for the next level
                //LoadLevel(currentLevel);
            }
            else
            {
                // Game completed
                Debug.Log("Congratulations! You've completed all levels!");
            }
        }
    }

    void LoadLevel(int level)
    {
        // Example of how you might load a new level
        // This could involve loading a new scene, or just changing the game state
        Debug.Log("Loading Level " + level);
        // SceneManager.LoadScene("Level" + level); // Uncomment if using scenes for levels

        // Additional logic to set up the new level
        // e.g., spawn enemies, set up the environment, etc.
    }

}
