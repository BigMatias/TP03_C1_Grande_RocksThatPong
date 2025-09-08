using UnityEngine;

public class PowerUpDefense : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject DefenseRockP1;
    [SerializeField] private GameObject DefenseRockP2;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private SpawnablesData SpawnablesData;

    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float yLocationP1 = Random.Range(-3.8f, 3.6f);
        float yLocationP2 = Random.Range(-3.8f, 3.6f);

        gameObject.SetActive(false);

        DefenseRockP1.gameObject.SetActive(true);
        DefenseRockP1.transform.position = new Vector3(-8.1f, yLocationP1);
        gameManager.DefenseCalled(SpawnablesData.defenseSeconds, DefenseRockP1);

        DefenseRockP2.gameObject.SetActive(true);
        DefenseRockP2.transform.position = new Vector3(8.15f, yLocationP2);

        gameManager.DefenseCalled(SpawnablesData.defenseSeconds, DefenseRockP2);
    }
}
