using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BallData BallData;
    [SerializeField] private UIGame UIGame;
    [SerializeField] private PlayerMovement PlayerMovement;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private AudioClip bounceOnPlayer;
    [SerializeField] private AudioClip bounceOnScreen;
    [SerializeField] private AudioClip bounceOnObstacle;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private GameManager gameManager;
    private AudioSource audioSource;
    private UIGame uiGame;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        uiGame = UIGame.GetComponent<UIGame>();
        gameManager = GameManager.GetComponent<GameManager>();
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
            KickOff();
        }
        if (collision.gameObject.CompareTag("Player 2 Goal"))
        {
            gameObject.SetActive(false);
            uiGame.UpdateScoreP1();
            KickOff();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            audioSource.PlayOneShot(bounceOnPlayer);
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + BallData.moreSpeed);
        }
        if (collision.gameObject.CompareTag("ScreenEdges"))
        {
            audioSource.PlayOneShot(bounceOnScreen);
        }
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            audioSource.PlayOneShot(bounceOnObstacle);
        }

    }


    public void KickOff()
    {
        float ballInitialDirX;
        float ballInitialDirY;
        float positiveDir = 5f;
        float negativeDir = -5f; 
        int choiceX = Random.Range(0, 2); 

        if (choiceX == 0)
        {
            ballInitialDirX = positiveDir;
        }
        else
        {
            ballInitialDirX = negativeDir;
        }

        int choiceY = Random.Range(0, 2);


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

        rb.AddForce(BallData.ballSpeed * new Vector2(ballInitialDirX, ballInitialDirY).normalized, ForceMode2D.Impulse);
    }

}
