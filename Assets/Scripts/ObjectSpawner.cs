using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class ObjectSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject Obstacle;
    [SerializeField] private GameObject Defense;
    [SerializeField] private GameObject DefenseRockP1;
    [SerializeField] private GameObject DefenseRockP2;
    [SerializeField] private GameObject MoreSize;
    [SerializeField] private GameObject FasterBall;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;

    [Header("Spawner Config")]

    [SerializeField] private float powerUpTimeTilDeactivation;
    [SerializeField] private float ballSpeedUp;
    [Header("Set location spawn range")]
    [SerializeField] private float xRangeFrom;
    [SerializeField] private float xRangeTo;
    [SerializeField] private float yRangeFrom;
    [SerializeField] private float yRangeTo;

    void Start()
    {
        Obstacle.gameObject.SetActive(false);
        Defense.gameObject.SetActive(false);
        DefenseRockP1.gameObject.SetActive(false);
        DefenseRockP2.gameObject.SetActive(false);
        MoreSize.gameObject.SetActive(false);
        FasterBall.gameObject.SetActive(false);

        InvokeRepeating("CreateObject", 10,10);
    }

    private void CreateObject() 
    {
        float choice = Random.Range(0, 5);
        float xLocation = Random.Range(xRangeFrom, xRangeTo);
        float yLocation = Random.Range(yRangeFrom, yRangeTo);
        if (choice >= 0 && choice <= 1 )
        {
            int seconds = Random.Range(3, 7);
            Obstacle.SetActive(true);
            Obstacle.transform.position = new Vector3(xLocation, yLocation,0);
            StartCoroutine(WaitAndDeactivate(seconds, Obstacle));
        }
        if (choice >= 1.1 && choice <= 2 )
        {
            Defense.SetActive(true);
            Defense.transform.position = new Vector3(xLocation, yLocation, 0);
            StartCoroutine(WaitAndDeactivate(powerUpTimeTilDeactivation, Defense));
        }
        if (choice >= 2.1 && choice <= 3 )
        {
            MoreSize.SetActive(true);
            MoreSize.transform.position = new Vector3(xLocation, yLocation, 0);
            StartCoroutine(WaitAndDeactivate(powerUpTimeTilDeactivation, MoreSize));
        }
        if (choice >= 3.1 && choice <= 4 )
        {
            FasterBall.SetActive(true);
            FasterBall.transform.position = new Vector3(xLocation, yLocation, 0);
            StartCoroutine(WaitAndDeactivate(powerUpTimeTilDeactivation, FasterBall));
        }
    }

    private IEnumerator WaitAndDeactivate(float seconds, GameObject gameObject)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }

 
 
}
