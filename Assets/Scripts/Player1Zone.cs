using UnityEngine;

public class Player1Zone : MonoBehaviour
{
    [SerializeField] GameSettings GameSettings;
    [SerializeField] UIGame UIGame;
    [SerializeField] BallMovement BallMovement;

    private float timer;

    private void Start()
    {
        timer = GameSettings.timeUntilScore;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            timer -= Time.deltaTime;
            if (timer <= 0.0f)
            {
                UIGame.UpdateScoreP1();
                BallMovement.KickOff();
                timer = GameSettings.timeUntilScore;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            timer = GameSettings.timeUntilScore;
        }
    }
}
