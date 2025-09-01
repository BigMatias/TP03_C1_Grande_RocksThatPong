using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIGame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] private GameManager GameManager;
    [Header("On Screen UI")]
    [Header("Scores")]
    [SerializeField] private TextMeshProUGUI playerScored;
    [SerializeField] private TextMeshProUGUI player1Score;
    [SerializeField] private TextMeshProUGUI player2Score;
    [SerializeField] public int winningScore;
    [SerializeField] private TextMeshProUGUI winText;
    [Header("Time")]
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] public float setTime;

    [NonSerialized] public float player1ScoreCounter;
    [NonSerialized] public float player2ScoreCounter;
    [NonSerialized] public int intTime;

    private UIPauseMenu pauseMenu;
    private GameManager gameManager;

    private void Awake()
    {
        pauseMenu = PauseMenu.GetComponent<UIPauseMenu>();
        gameManager = GameManager.GetComponent<GameManager>();

        // Inicializa tiempo
        time.text = setTime.ToString();

        player1Score.text = "0";
        player2Score.text = "0";

        playerScored.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTime();
        PlayerWins();
    }

    public void UpdateScoreP2()
    {
        player2ScoreCounter += 1;
        player2Score.text = player2ScoreCounter.ToString();

        playerScored.text = "Player 2 Scored";
        playerScored.gameObject.SetActive(true);
        StartCoroutine(ScorePause(3));
    }

    public void UpdateScoreP1()
    {
        player1ScoreCounter += 1;
        player1Score.text = player1ScoreCounter.ToString();

        playerScored.text = "Player 1 Scored";
        playerScored.gameObject.SetActive(true);
        StartCoroutine(ScorePause(3));
    }
    private void UpdateTime()
    {
        if (!pauseMenu.isPause)
        {
            setTime -= Time.deltaTime;
            time.text = setTime.ToString("0");

            if (setTime <= 0.0f)
            {
                TimeOut();
            }
        }
    }

    private void TimeOut()
    {
        winText.gameObject.SetActive(true);
        if (player1ScoreCounter > player2ScoreCounter)
        {
            winText.text = "Player 1 Wins!";
        }
        else
        {
            winText.text = "Player 2 Wins!";
        }
        if (player1ScoreCounter == player2ScoreCounter)
        {
            winText.text = "Tie!";
        }
        StartCoroutine(EndGamePause(3));

    }


    private void PlayerWins()
    {
        if (player1ScoreCounter == winningScore || player2ScoreCounter == winningScore)
        {
            if (player1ScoreCounter == winningScore)
            {
                winText.text = "Player 1 Wwins!";
            }
            else
            {
                winText.text = "Player 2 Wins!";
            }
            StartCoroutine(EndGamePause(3));
        }
    }

    private IEnumerator ScorePause(float seconds)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;

        playerScored.gameObject.SetActive(false);
    }
    private IEnumerator EndGamePause(float seconds)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;

        gameManager.ReturnToMainMenu();
    }

}
