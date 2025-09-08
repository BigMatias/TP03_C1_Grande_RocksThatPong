using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private PlayerData PlayerData;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(PlayerData.keyUp))
        {
            Rigidbody2D rigidbody2D = rb;
            rb.AddForce(PlayerData.velocity * Time.fixedDeltaTime * Vector2.up);
        }
        if (Input.GetKey(PlayerData.keyDown))
        {
            Rigidbody2D rigidbody2D = rb;
            rb.AddForce(PlayerData.velocity * Time.fixedDeltaTime * Vector2.down);
        }
        if (Input.GetKey(PlayerData.keyRight))
        {
            Rigidbody2D rigidbody2D = rb;
            rb.AddForce(PlayerData.velocity * Time.fixedDeltaTime * Vector2.right);
        }
        if (Input.GetKey(PlayerData.keyLeft))
        {
            Rigidbody2D rigidbody2D = rb;
            rb.AddForce(PlayerData.velocity * Time.fixedDeltaTime * Vector2.left);
        }
    }

    public void PlayerScored()
    {
        float p1StartingPositionX = -7.81f;
        float p1StartingPositionY = -0.15f;
        Player1.transform.position = new Vector3(p1StartingPositionX, p1StartingPositionY);

        float p2StartingPositionX = -p1StartingPositionX;
        float p2StartingPositionY = p1StartingPositionY;
        Player2.transform.position = new Vector3(p2StartingPositionX, p2StartingPositionY);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si choca con la pelota cambia el color a uno aleatorio
        if (collision.gameObject.CompareTag("Ball"))
        {
            sprite.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }

        // Si choca con los bordes cambia el color a negro
        if (collision.gameObject.CompareTag("ScreenEdges"))
        {
            sprite.color = new Color(0, 0, 0);
        }
    }
}
