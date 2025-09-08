using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpawnablesData SpawnablesData;
    [SerializeField] private GameObject Obstacle;
    [SerializeField] private GameObject Defense;
    [SerializeField] private GameObject DefenseRockP1;
    [SerializeField] private GameObject DefenseRockP2;
    [SerializeField] private GameObject MoreSize;
    [SerializeField] private GameObject FasterBall;
    [SerializeField] private GameObject Ball;
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;

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
        float xLocation = Random.Range(SpawnablesData.xRangeFrom, SpawnablesData.xRangeTo);
        float yLocation = Random.Range(SpawnablesData.yRangeFrom, SpawnablesData.yRangeTo);
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
            StartCoroutine(WaitAndDeactivate(SpawnablesData.powerUpTimeTilDeactivation, Defense));
        }
        if (choice >= 2.1 && choice <= 3 )
        {
            MoreSize.SetActive(true);
            MoreSize.transform.position = new Vector3(xLocation, yLocation, 0);
            StartCoroutine(WaitAndDeactivate(SpawnablesData.powerUpTimeTilDeactivation, MoreSize));
        }
        if (choice >= 3.1 && choice <= 4 )
        {
            FasterBall.SetActive(true);
            FasterBall.transform.position = new Vector3(xLocation, yLocation, 0);
            StartCoroutine(WaitAndDeactivate(SpawnablesData.powerUpTimeTilDeactivation, FasterBall));
        }
    }

    private IEnumerator WaitAndDeactivate(float seconds, GameObject gameObject)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }

 
 
}
