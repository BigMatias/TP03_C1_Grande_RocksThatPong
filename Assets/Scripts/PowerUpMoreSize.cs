using UnityEngine;

public class PowerUpMoreSize : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject Player1;
    [SerializeField] private GameObject Player2;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private SpawnablesData SpawnablesData;


    private GameManager gameManager;

    private void Awake()
    {
        gameManager = GameManager.GetComponent<GameManager>();
    } 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameObject.SetActive(false);

        Player1.transform.localScale += new Vector3(0, SpawnablesData.addedHeight, 0);
        Player2.transform.localScale += new Vector3(0, SpawnablesData.addedHeight, 0);

        gameManager.MoreSizeCalled(SpawnablesData.moreSizeSeconds, SpawnablesData.addedHeight);
    }


}
