using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


#if UNITY_EDITOR
using UnityEngine;
#endif

public class UIPauseMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject panelPause;
    [SerializeField] private UIGame UIGame;

    [SerializeField] private Button btnPlay;
    [SerializeField] private Button btnOptions;
    [SerializeField] private Button btnMainMenu;
    [SerializeField] private Button btnExit;
    [SerializeField] private PlayerData Player1Data;
    [SerializeField] private PlayerData Player2Data;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private GameObject Ball;

    [Header("Speed Settings")]
    [Header("Player 1")]
    [SerializeField] private TextMeshProUGUI player1SpeedText;
    [SerializeField] private Slider sliderSpeedPlayer1;

    [Header("Player 2")]
    [SerializeField] private TextMeshProUGUI player2SpeedText;
    [SerializeField] private Slider sliderSpeedPlayer2;

    [Header("Color Settings")]
    [Header("Player 1")]
    [SerializeField] private Slider sliderRedPlayer1;
    [SerializeField] private Slider sliderGreenPlayer1;
    [SerializeField] private Slider sliderBluePlayer1;

    [Header("Player 2")]
    [SerializeField] private Slider sliderRedPlayer2;
    [SerializeField] private Slider sliderGreenPlayer2;
    [SerializeField] private Slider sliderBluePlayer2;

    [Header("Height Settings")]
    [Header("Player 1")]
    [SerializeField] private Slider sliderHeightPlayer1;

    [Header("Player 2")]
    [SerializeField] private Slider sliderHeightPlayer2;

    [Header("Options")]
    [SerializeField] private Button btnOptionsBack;
    [SerializeField] private GameObject panelOptions;

    [NonSerialized] public bool isPause = false;


    private SpriteRenderer player1Sprite;
    private SpriteRenderer player2Sprite;

    private void Awake()
    {
        player1Sprite = Player1.GetComponent<SpriteRenderer>();
        player2Sprite = Player2.GetComponent<SpriteRenderer>();

        // Inicializar valores minimos y máximos de sliders de velocidad
        sliderSpeedPlayer1.minValue = 50f;
        sliderSpeedPlayer1.maxValue = 100f;
        sliderSpeedPlayer2.minValue = 50f;
        sliderSpeedPlayer2.maxValue = 100f;

        //Valor de velocidad inicial del slider de velocidad
        sliderSpeedPlayer1.value = Player1Data.velocity / 100;
        sliderSpeedPlayer2.value = Player2Data.velocity / 100;
        player1SpeedText.text = (Player1Data.velocity / 100).ToString();
        player2SpeedText.text = (Player2Data.velocity / 100).ToString();

        // Inicializar valores minimos y máximos de los sliders de altura
        sliderHeightPlayer1.minValue = 1;
        sliderHeightPlayer1.maxValue = 4;
        sliderHeightPlayer2.minValue = 1;
        sliderHeightPlayer2.maxValue = 4;

        // Valor de altura inicial del slider de altura
        sliderHeightPlayer1.value = Player1.transform.localScale.y;
        sliderHeightPlayer2.value = Player2.transform.localScale.y;

        // Inicializar valores mínimos y máximos de los sliders de color
        sliderRedPlayer1.minValue = 0f;
        sliderGreenPlayer1.minValue = 0f;
        sliderBluePlayer1.minValue = 0f;
        sliderRedPlayer1.maxValue = 1f;
        sliderGreenPlayer1.maxValue = 1f;
        sliderBluePlayer1.maxValue = 1f;

        sliderRedPlayer2.minValue = 0f;
        sliderGreenPlayer2.minValue = 0f;
        sliderBluePlayer2.minValue = 0f;
        sliderRedPlayer2.maxValue = 1f;
        sliderGreenPlayer2.maxValue = 1f;
        sliderBluePlayer2.maxValue = 1f;

        // Valor de color inicial de los sliders de color
        sliderRedPlayer1.value = player1Sprite.color.r;
        sliderGreenPlayer1.value = player1Sprite.color.g;
        sliderBluePlayer1.value = player1Sprite.color.b;
        sliderRedPlayer2.value = player2Sprite.color.r;
        sliderGreenPlayer2.value = player2Sprite.color.g;
        sliderBluePlayer2.value = player2Sprite.color.b;

        panelPause.SetActive(false);
        panelOptions.SetActive(false);

        btnPlay.onClick.AddListener(OnPlayClicked);
        btnOptions.onClick.AddListener(OnOptionsClicked);
        btnMainMenu.onClick.AddListener(OnMainMenuClicked);
        btnOptionsBack.onClick.AddListener(OnBackOptionsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void Update()
    {

        ChangePlayerSpeed();
        ChangePlayerColor();
        ChangePlayerHeight();
        if (Input.GetKeyDown(KeyCode.Escape) && UIGame.justScored == false)
        {   
            TogglePause();
        }
    }

    private void OnDestroy()
    {
        btnPlay.onClick.AddListener(OnPlayClicked);
        btnOptions.onClick.AddListener(OnOptionsClicked);
        btnOptionsBack.onClick.AddListener(OnBackOptionsClicked);
        btnMainMenu.onClick.AddListener(OnMainMenuClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void ChangePlayerSpeed()
    {
        //Cambia la velocidad del Player 1/2 deslizando el slider, también el valor del texto asociado.
        sliderSpeedPlayer1.onValueChanged.AddListener((v) => {
            Player1Data.velocity = v * 100;
            player1SpeedText.text = v.ToString();
        });
        sliderSpeedPlayer2.onValueChanged.AddListener((v) => {
            Player2Data.velocity = v * 100;
            player2SpeedText.text = v.ToString();
        });
    }
    private void ChangePlayerHeight()
    {
        sliderHeightPlayer1.onValueChanged.AddListener((h) => {
            Player1.transform.localScale = new Vector3(Player1.transform.localScale.x, h, Player1.transform.localScale.z);
        });
        sliderHeightPlayer2.onValueChanged.AddListener((h) => {
            Player2.transform.localScale = new Vector3(Player2.transform.localScale.x, h, Player2.transform.localScale.z);
        });
    }

    private void ChangePlayerColor()
    {
        // Player 1 Colors
        sliderRedPlayer1.onValueChanged.AddListener((r) => {
            player1Sprite.color = new Color(r, player1Sprite.color.g, player1Sprite.color.b);
        });
        sliderGreenPlayer1.onValueChanged.AddListener((g) => {
            player1Sprite.color = new Color(player1Sprite.color.r, g, player1Sprite.color.b);
        });
        sliderBluePlayer1.onValueChanged.AddListener((b) => {
            player1Sprite.color = new Color(player1Sprite.color.r, player1Sprite.color.g, b);
        });


        // Player 2 Colors 
        sliderRedPlayer2.onValueChanged.AddListener((r) => {
            player2Sprite.color = new Color(r, player2Sprite.color.g, player2Sprite.color.b);
        });
        sliderGreenPlayer2.onValueChanged.AddListener((g) => {
            player2Sprite.color = new Color(player2Sprite.color.r, g, player2Sprite.color.b);
        });
        sliderBluePlayer2.onValueChanged.AddListener((b) => {
            player2Sprite.color = new Color(player2Sprite.color.r, player2Sprite.color.g, b);
        });
    }

    private void OnPlayClicked()
    {
        TogglePause();
    }

    private void OnOptionsClicked()
    {
        panelOptions.SetActive(true);
    }
    private void OnBackOptionsClicked()
    {
        panelOptions.SetActive(false);
    }
    private void OnMainMenuClicked()
    {
        SceneManager.LoadScene("Main Menú");
    }
    private void OnExitClicked()
    {
        //Sale del estado "Play" del editor si este está en true, de lo contrario sale de la aplicación si esta es una build.  
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void TogglePause()
    {
        isPause = !isPause;
        if (isPause)
        {
            panelPause.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            panelPause.SetActive(false);
            panelOptions.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}
