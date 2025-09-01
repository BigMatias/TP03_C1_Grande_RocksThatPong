using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private UIGame UIGame;
    [SerializeField] private PlayerMovement PlayerMovement;
    [SerializeField] private GameObject GameManager;
    
    [Header("Speed Settings")]
    [SerializeField] private float ballSpeed;
    [SerializeField] public float moreSpeed = 10;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private PlayerMovement playerMovement;
    private GameManager gameManager;

    private UIGame uiGame;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        uiGame = UIGame.GetComponent<UIGame>();
        gameManager = GameManager.GetComponent<GameManager>();
        playerMovement = PlayerMovement.GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        KickOff();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player 1 Goal"))
        { 
            gameObject.SetActive(false);
            uiGame.UpdateScoreP2();
            playerMovement.PlayerScored();
            KickOff();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + moreSpeed);
        }
        if (collision.gameObject.CompareTag("Player 2 Goal"))
        {
            gameObject.SetActive(false);
            uiGame.UpdateScoreP1();
            playerMovement.PlayerScored();
            KickOff();
        }
    }


    public void KickOff()
    {
        float ballInitialDirX;
        float ballInitialDirY;
        float positiveDir = 5f;
        float negativeDir = -5f; 
        int choiceX = UnityEngine.Random.Range(0, 2); 

        if (choiceX == 0)
        {
            ballInitialDirX = positiveDir;
        }
        else
        {
            ballInitialDirX = negativeDir;
        }

        int choiceY = UnityEngine.Random.Range(0, 2);


        if (choiceY == 0)
        {
            ballInitialDirY = positiveDir;
        }
        else
        {
            ballInitialDirY = negativeDir;
        }

        gameObject.SetActive(true);
        sprite.color = Color.white;
        gameObject.transform.position = new Vector3(0, 0, 0);
        if (gameManager != null)
        {
            gameManager.StopSpeedCoroutine();
        }

        rb.AddForce(ballSpeed * Time.fixedDeltaTime * new Vector2(ballInitialDirX, ballInitialDirY));
    }

}
