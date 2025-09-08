using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data", order = 1)]

public class PlayerData : ScriptableObject
{
    [Header("Speed Setup")]
    public float velocity = 1000f;

    [Header("Movement Keys")]
    public KeyCode keyUp = KeyCode.W;
    public KeyCode keyDown = KeyCode.S;
    public KeyCode keyLeft = KeyCode.A;
    public KeyCode keyRight = KeyCode.D;
}
