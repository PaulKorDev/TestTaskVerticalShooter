using UnityEngine;

[CreateAssetMenu (fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig")]
public class GameConfig : ScriptableObject
{
    public PlayerAttackConfig PlayerAttackConfig; 
    public EnemyFactoryConfig EnemyFactoryConfig;
}
