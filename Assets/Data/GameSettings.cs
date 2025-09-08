using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings", order = 1)]

public class GameSettings : ScriptableObject
{
    [Header("Score settings")]
    public float score = 5;
    public float timeUntilScore = 20;
    public float timeUntilGameEnd = 200;
}
