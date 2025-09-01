using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [Header("Speed Setup")]
    [SerializeField] public float velocity = 1000f;

    [Header("Movement Keys")]
    [SerializeField] private KeyCode keyUp = KeyCode.W;
    [SerializeField] private KeyCode keyDown = KeyCode.S;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (Input.GetKey(keyUp))
        {
            Rigidbody2D rigidbody2D = rb;
            rb.AddForce(velocity * Time.fixedDeltaTime * Vector2.up);
        }
        if (Input.GetKey(keyDown))
        {
            Rigidbody2D rigidbody2D = rb;
            rb.AddForce(velocity * Time.fixedDeltaTime * Vector2.down);
        }
    }

    public void PlayerScored()
    {
        float p1StartingPositionX = -7.81f;
        float p1StartingPositionY = -0.15f;
        Player1.transform.position = new Vector3(p1StartingPositionX, p1StartingPositionY);

        float p2StartingPositionX = 7.81f;
        float p2StartingPositionY = -0.15f;
        Player2.transform.position = new Vector3(p2StartingPositionX, p2StartingPositionY);


    }

}
