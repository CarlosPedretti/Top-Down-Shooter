using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Audio;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject WinScene;
    [SerializeField] public Image timerBar;

    public float delayBeforeGameOver = 1f;


    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    public float duration = 60f; 
    private float elapsedTime;
    private bool isTimerRunning;

    private void Start()
    {
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= duration)
            {
                elapsedTime = duration;
                isTimerRunning = false;
                WinScreen();
            }

            float remainingTime = duration - elapsedTime;
            UpdateTimerBar(remainingTime / duration);

        }
    }


    private void UpdateTimerBar(float fillAmount)
    {
        timerBar.fillAmount = fillAmount;
    }


    private void StartTimer()
    {
        isTimerRunning = true;
    }

    public void ShowGameOverScreen()
    {
        Invoke("ShowGameOver", delayBeforeGameOver);
    }

    public void ShowGameOver()
    {
        GameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void WinScreen()
    {
        WinScene.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
