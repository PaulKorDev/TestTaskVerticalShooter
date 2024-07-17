using Assets.Scripts.Architecture.ServiceLocator;
using UnityEngine;

[CreateAssetMenu (fileName = "GameConfig", menuName = "ScriptableObjects/GameConfig")]
public class GameConfig : ScriptableObject, IService
{
    public PlayerAttackConfig PlayerAttackConfig; 
    public EnemyFactoryConfig EnemyFactoryConfig;
}
