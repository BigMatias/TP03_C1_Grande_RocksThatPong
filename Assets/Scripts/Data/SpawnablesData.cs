using UnityEngine;

[CreateAssetMenu(fileName = "Spawnables", menuName = "Spawnables/Data", order = 1)]

public class SpawnablesData : ScriptableObject
{
    [Header("Spawner Config")]
    public float powerUpTimeTilDeactivation;
    public float ballSpeedUp;

    [Header("Set location spawn range")]
    public float xRangeFrom;
    public float xRangeTo;
    public float yRangeFrom;
    public float yRangeTo;

    [Header("Faster Ball Setup")]
    public float ballAddedSpeed;
    public float secondsUntilExpired;

    [Header("More Size Setup")]
    public float addedHeight;
    public float moreSizeSeconds;

    [Header("Defense Setup")]
    public float defenseSeconds;
}
