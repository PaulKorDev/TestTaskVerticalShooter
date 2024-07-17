using UnityEngine;

[CreateAssetMenu (fileName = "EnemyFactoryConfig", menuName = "ScriptableObjects/EnemyFactoryConfig")]
public class EnemyFactoryConfig : ScriptableObject
{
    public int EnemyHP;

    [Header("Count")]
    public int EnemyCountMin;
    public int EnemyCountMax;

    [Header("Timeout")]
    public float TimeoutMin;
    public float TimeoutMax;

    [Header("Speed")]
    public float SpeedMin;
    public float SpeedMax;
}
