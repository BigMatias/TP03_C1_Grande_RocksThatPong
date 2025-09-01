using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PowerUpMoreSize : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private GameObject GameManager;

    [Header("Setup")]
    [SerializeField] private float addedHeight;
    [SerializeField] private float seconds;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.GetComponent<GameManager>();
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);

        Player1.transform.localScale += new Vector3(0, addedHeight, 0);
        Player2.transform.localScale += new Vector3(0, addedHeight, 0);

        gameManager.MoreSizeCalled(seconds, addedHeight);
    }


}
