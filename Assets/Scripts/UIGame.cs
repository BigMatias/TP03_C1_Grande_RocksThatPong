using System;
using System.Collections;
using UnityEngine;
using TMPro;

public class UIGame : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameManager GameManager;
    [SerializeField] private GameSettings GameSettings;
    [SerializeField] private Player1Zone Player1Zone;
    [SerializeField] private Player2Zone Player2Zone;

    [Header("On Screen UI")]
    [Header("Scores")]
    [SerializeField] private TextMeshProUGUI playerScored;
    [SerializeField] private TextMeshProUGUI player1Score;
    [SerializeField] private TextMeshProUGUI player2Score;
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private TextMeshProUGUI time;

    [NonSerialized] public float player1ScoreCounter;
    [NonSerialized] public float player2ScoreCounter;
    [NonSerialized] public bool justScored;

    private UIPauseMenu pauseMenu;
    private GameManager gameManager;
    private float globalTime;

    private void Awake()
    {
        pauseMenu = PauseMenu.GetComponent<UIPauseMenu>();
        gameManager = GameManager.GetComponent<GameManager>();

        // Inicializa tiempo
        globalTime = GameSettings.timeUntilGameEnd;
        time.text = globalTime.ToString();

        player1Score.text = "0";
        player2Score.text = "0";

        playerScored.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {   
        UpdateTime();
    }

    public void UpdateScoreP2()
    {
        player2ScoreCounter += 1;
        player2Score.text = player2ScoreCounter.ToString();
        if (player2ScoreCounter >= GameSettings.score)
        {
            winText.gameObject.SetActive(true);
            winText.text = "Player 2 Wins!";
            StartCoroutine(EndGamePause(3));
        }
        else
        {
            playerScored.text = "Player 2 Scored";
            playerScored.gameObject.SetActive(true);
            playerMovement.PlayerScored();
            StartCoroutine(ScorePause(3));
        }
    }

    public void UpdateScoreP1()
    {
        player1ScoreCounter += 1;
        player1Score.text = player1ScoreCounter.ToString();
        if (player1ScoreCounter >= GameSettings.score)
        {
            winText.gameObject.SetActive(true);
            winText.text = "Player 1 Wins!";
            StartCoroutine(EndGamePause(3));
        }
        else
        {
            playerScored.text = "Player 1 Scored";
            playerScored.gameObject.SetActive(true);
            playerMovement.PlayerScored();
            StartCoroutine(ScorePause(3));
        }
    }
    private void UpdateTime()
    {
        if (!pauseMenu.isPause)
        {
            globalTime -= Time.deltaTime;
            time.text = globalTime.ToString("0");

            if (globalTime <= 0.0f)
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
        else if (player1ScoreCounter < player2ScoreCounter)
        {
            winText.text = "Player 2 Wins!";
        }
        if (player1ScoreCounter == player2ScoreCounter)
        {
            winText.text = "Tie!";
        }
        StartCoroutine(EndGamePause(3));

    }

    public IEnumerator ScorePause(float seconds)
    {
        justScored = true;
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;

        playerScored.gameObject.SetActive(false);
        justScored = false;
    }
    private IEnumerator EndGamePause(float seconds)
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;

        gameManager.ReturnToMainMenu();
    }

}
