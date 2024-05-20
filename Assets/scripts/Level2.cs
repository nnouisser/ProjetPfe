using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class Level2 : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI enemiesKilledText;
    public GameObject winImage;
    public ButtonManager buttonManager; // Reference to ButtonManager

    public int enemiesToKill = 30;
    public float totalTimeInSeconds = 900f;

    private int enemiesKilled = 0;
    private float currentTime = 0f;
    private bool isGameOver = false;
    private bool isTimerStarted = false; // Flag to indicate if the timer has started

    void Start()
    {
        // Ensure that the timerText GameObject is inactive at the start
        if (timerText != null)
        {
            timerText.gameObject.SetActive(false); // Set timerText inactive initially
        }
        else
        {
            Debug.LogError("Timer Text reference is not set in Level2 script!");
        }
        if (enemiesKilledText != null)
        {
            enemiesKilledText.gameObject.SetActive(false); // Set enemiesKilledText inactive initially
        }

        if (buttonManager != null)
        {
            // Subscribe to the event
            buttonManager.OnButtonManagerFinished += StartLevel;
        }
        else
        {
            Debug.LogError("ButtonManager reference is not set in Level2 script!");
        }
    }

    void Update()
    {
        if (!isGameOver && isTimerStarted)
        {
            UpdateTimer();
        }
    }

    IEnumerator StartTimer()
    {
        while (currentTime < totalTimeInSeconds)
        {
            yield return new WaitForSeconds(1f);
            currentTime++;
            UpdateTimer();
        }

        if (enemiesKilled < enemiesToKill)
        {
            GameOver();
        }
    }

    void UpdateTimer()
    {
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        timerText.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }

    public void EnemyKilled()
    {
        enemiesKilled++;
        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled.ToString();

        if (enemiesKilled >= enemiesToKill)
        {
            StartCoroutine(WinCoroutine());
        }
    }

    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator WinCoroutine()
    {
        // Activate the win image
        if (winImage != null)
        {
            winImage.SetActive(true);
        }
        else
        {
            Debug.LogError("Win Image reference is not set in Level2 script!");
        }

        yield return new WaitForSeconds(2f);

        // Deactivate the win image after 2 seconds
        if (winImage != null)
        {
            winImage.SetActive(false);
        }
    }

    void StartLevel()
    {
        enemiesKilled = 0;
        enemiesKilledText.text = "Enemies Killed: " + enemiesKilled.ToString();
        StartCoroutine(StartTimer());

        // Activate the timer text
        if (timerText != null)
        {
            timerText.gameObject.SetActive(true);
            isTimerStarted = true; // Set the flag to indicate timer has started
        } if (enemiesKilledText != null)
        {
            enemiesKilledText.gameObject.SetActive(true);
        }
    }
}
