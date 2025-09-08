using UnityEngine;

[CreateAssetMenu(fileName = "Ball", menuName = "Data", order = 1)]

public class BallData : ScriptableObject
{
    [Header("Speed Settings")]
    public float ballSpeed = 1.0f;
    public float moreSpeed = 1.0f;
}
