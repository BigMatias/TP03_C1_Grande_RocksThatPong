using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using System;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEngine;
#endif

public class UIMainMenu : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Button BtnPlay;
    [SerializeField] private Button BtnCredits;
    [SerializeField] private Button BtnBackCredits;
    [SerializeField] private Button BtnExit;
    [SerializeField] private Image Logo;
    [SerializeField] private GameObject Credits;

    // Start is called before the first frame update


    private void Awake()
    {
        Credits.SetActive(false);

        BtnPlay.onClick.AddListener(StartGame);
        BtnCredits.onClick.AddListener(ShowCredits);
        BtnExit.onClick.AddListener(QuitGame);
        BtnBackCredits.onClick.AddListener(OnBackCreditsClicked);
    }

    private void OnDestroy()
    {
        BtnPlay.onClick.AddListener(StartGame);
        BtnCredits.onClick.AddListener(ShowCredits);
        BtnExit.onClick.AddListener(QuitGame);
        BtnBackCredits.onClick.AddListener(OnBackCreditsClicked);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    private void ShowCredits()
    {
        Logo.gameObject.SetActive(false);
        BtnPlay.gameObject.SetActive(false);
        BtnCredits.gameObject.SetActive(false);
        BtnExit.gameObject.SetActive(false);

        Credits.SetActive(true);
    }
    private void OnBackCreditsClicked()
    {
        Logo.gameObject.SetActive(true);
        BtnPlay.gameObject.SetActive(true);
        BtnCredits.gameObject.SetActive(true); 
        BtnExit.gameObject.SetActive(true); 

        Credits.SetActive(false);
    }

    private void QuitGame()
    {
        //Sale del estado "Play" del editor si estamos en el editor, de lo contrario sale de la aplicación si esta es una build.  
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }



}
