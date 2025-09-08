using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject Ball;
    [SerializeField] GameObject Player1;
    [SerializeField] GameObject Player2;
    [SerializeField] PowerUpMoreSize MoreSize;
    [SerializeField] PowerUpDefense Defense;

    private Rigidbody2D ballRb;
    private SpriteRenderer ballSprite;
    private Coroutine speedCoroutine;

    private void Awake()
    {
        Time.timeScale = 1;
        ballRb = Ball.GetComponent<Rigidbody2D>();    
        ballSprite = Ball.GetComponent<SpriteRenderer>();

    }

    public void PauseGameForSeconds(float secondsToPause)
    {
        StartCoroutine(PauseRoutine(secondsToPause));
    }

    public IEnumerator PauseRoutine(float seconds)
    {
        // Set Time.timeScale to 0 to pause all time-based operations
        Time.timeScale = 0f;

        // This ensures the wait still functions even when timeScale is 0
        yield return new WaitForSecondsRealtime(seconds);

        // Set Time.timeScale back to 1 to resume the game
        Time.timeScale = 1f;
    }

    public void ReturnToMainMenu()
    {
        PauseGameForSeconds(5);
        SceneManager.LoadScene("Main Menú");
    }

    public void FasterBallCalled(float seconds, float ballSpeedUp)
    {
        // Si ya hay una coroutine corriendo, la detiene primero
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
        }

        // Inicia la coroutine y guarda la referencia
        speedCoroutine = StartCoroutine(WaitAndNormalSpeed(seconds, ballSpeedUp));
    }

    // Método público para detener la coroutine.
    // Este se llama cuando la pelota se reinicia.
    public void StopSpeedCoroutine()
    {
        if (speedCoroutine != null)
        {
            StopCoroutine(speedCoroutine);
            speedCoroutine = null;
        }
    }

    private IEnumerator WaitAndNormalSpeed(float seconds, float ballSpeedUp)
    {
        yield return new WaitForSeconds(seconds);

        if (ballRb.velocity.magnitude > 0)
        {
            ballRb.velocity = ballRb.velocity.normalized * (ballRb.velocity.magnitude - ballSpeedUp);
            ballSprite.color = Color.white;
        }

        speedCoroutine = null;
    }

    public void MoreSizeCalled(float seconds, float addedHeight)
    {
        StartCoroutine(WaitAndReturnNormalSize(seconds, addedHeight));
    }

    private IEnumerator WaitAndReturnNormalSize(float seconds, float addedHeight)
    {
        yield return new WaitForSeconds(seconds);

        Player1.transform.localScale -= new Vector3(0, addedHeight, 0); ;
        Player2.transform.localScale -= new Vector3(0, addedHeight, 0); ;
    }
    public void DefenseCalled(float seconds, GameObject gameObject)
    {
        StartCoroutine(WaitAndDeactivateDefenses(seconds, gameObject));
    }

    private IEnumerator WaitAndDeactivateDefenses(float seconds, GameObject gameObject)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }

}
