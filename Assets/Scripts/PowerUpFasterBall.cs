using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFasterBall : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject GameManager;

    [Header("Setup")]
    [SerializeField] private float ballSpeedUp;
    [SerializeField] private float secondsUntilExpired;
    
    private SpriteRenderer ballSprite;
    private Rigidbody2D ballRb;
    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.GetComponent<GameManager>();
        ballSprite = Ball.GetComponent<SpriteRenderer>();
        ballRb = Ball.GetComponent<Rigidbody2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        gameObject.SetActive(false);
        ballSprite.color = new Color(1f, 0.7f, 0f);
        ballRb.velocity = ballRb.velocity.normalized * (ballRb.velocity.magnitude + ballSpeedUp);

        gameManager.FasterBallCalled(secondsUntilExpired, ballSpeedUp);

    }

}
